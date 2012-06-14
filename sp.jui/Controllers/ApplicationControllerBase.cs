﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI.WebControls;
using sp.jui.Commands;
using sp.jui.Commons;
using sp.jui.Events.Arguments;
using sp.jui.Events.Handlers;
using sp.jui.Views;

namespace sp.jui.Controllers
{
    public abstract class ApplicationControllerBase :
        WebControl,
        ILoadCommandViewBinding,
        IDetermineCurrentViewName,
        IDetermineNotificationViewName,
        IDetermineInitialEvent,
        IDetermineModels,
        IApplicationContext
    {
        protected IDictionary<string, ApplicationViewBase> Views;
        protected IDictionary<string, string> Mapping;
        protected IDictionary<string, IApplicationContextAccessible> Commands;


        private readonly IDictionary<string, string> _contextValues = new Dictionary<string, string>();

        string IApplicationContext.this[string key]
        {
            get { return _contextValues.ContainsKey(key) == false ? null : _contextValues[key]; }
            set
            {
                if (_contextValues.ContainsKey(key) != true) _contextValues.Remove(key);
                _contextValues.Add(key, value);
            }
        }

        public string CurrentViewName
        {
            set
            {
                var state = this.ViewState["LastViewMode"];
                if (state != null) this.ViewState.Remove("LastViewMode");
                this.ViewState.Add("LastViewMode", value);
            }
            get
            {
                var state = this.ViewState["LastViewMode"];
                if (state == null) return null;
                return (string) state;
            }
        }

        private void SwitchView<T>(IHideable sender, string viewName, ActionPerformedEventArgs<T> args)
            where T : IModel, new()
        {
            this.SwitchView(sender, viewName);

            this.RaiseViewSwitch(args, this.OnViewSwitch, viewName);

            if (sender is IActionPerformer<T>) this.CurrentViewName = viewName;
        }

        protected void OnInitialActionPerformed<T>(string viewName, string commandName) where T : IModel, new()
        {
            var viewModeable = (IActionPerformer<T>) Views[viewName];

            this.OnActionPerformed(
                viewModeable,
                new ActionPerformedEventArgs<T>(
                    new ViewSwitchedEventArgs<T>(null)
                        {
                            CurrentViewName = viewName
                        })
                    {
                        CommandName = commandName
                    });
        }

        private ApplicationViewBase GetNextView(string viewName)
        {
            var nextView = Views[viewName];
            nextView.CurrentViewName = viewName;
            return nextView;
        }

        private void SwitchView(IHideable sender, string viewName)
        {
            var nextView = this.GetNextView(viewName);
            if (!sender.Equals(nextView))
            {
                sender.Hide();
            }
            nextView.Show();
        }

        private void RaiseViewSwitch<T>(ActionPerformedEventArgs<T> args,
                                        ViewSwitchedMethodDelegate<T> viewSwitchedMethod, string viewName)
            where T : IModel, new()
        {
            viewSwitchedMethod(new ViewSwitchedEventArgs<T>(args)
                                   {
                                       DataItem = args.DataItem,
                                       CurrentViewName = viewName,
                                       PreviousViewName = this.CurrentViewName
                                   });

            this.CurrentViewName = viewName;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.CurrentViewName != null) return;

            var type = this.GetType();
            var onInitialActionPerformed = type.GetMethod("OnInitialActionPerformed", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);

            var method = onInitialActionPerformed.MakeGenericMethod(new[] { this.InitialModel.GetType() } );

            method.Invoke(this, new object[] {this.InitialViewName, this.InitialCommandName});
        }

        protected void ShowNotification<T>(ICollection<T> list)
        {
            var infoView = this.Views[this.NotificationViewName];
            ((IBindable<ICollection<T>>) infoView).Bind(list);
            infoView.Show();
        }

        protected void FireViewSwitched<T>(ViewSwitchedEventArgs<T> args, ViewSwitchedHandler<T> viewSwitchedHandler)
            where T : IModel, new()
        {
            if (args == null || viewSwitchedHandler == null) return;

            viewSwitchedHandler((IViewSwitchedInvoker<T>) this, args);
        }

        protected abstract void OnViewSwitch<T>(ViewSwitchedEventArgs<T> args)
            where T : IModel, new();

        protected virtual void OnBeforeViewSwitch<T>(IDetermineCurrentViewName viewModeable, ICommand<T> command)
            where T : IModel, new()
        {
        }

        protected void BindOnActionPerformedEvent<T>()
            where T : IModel, new()
        {
            foreach (var view in Views)
            {
                view.Value.ActionContext = this;

                if (view.Value is IActionPerformer<T>)
                {
                    var actionPerformer = ((IActionPerformer<T>) view.Value);

                    actionPerformer.ActionPerformed -= this.OnActionPerformed;
                    actionPerformer.ActionPerformed += this.OnActionPerformed;

                    if (view.Value is IActionPerformerParent<T>)
                    {
                        var parent = (IActionPerformerParent<T>) view.Value;
                        foreach (var c in parent.ChildActionPerformer)
                        {
                            c.ActionPerformed -= this.OnActionPerformed;
                            c.ActionPerformed += this.OnActionPerformed;
                        }
                    }
                }

                var listenerView = view.Value as ICanObserverViewSwitched;
                ((IViewSwitchedInvoker<T>) this).ViewSwitched += listenerView.OnViewModeChanged;
            }
        }

        public bool OnActionPerformed<T>(IActionPerformer<T> sender, ActionPerformedEventArgs<T> args)
            where T : IModel, new()
        {
            if (this.Commands.ContainsKey(args.CommandName) == false) return false;

            var command = this.Commands[args.CommandName] as ICommand<T>;
            if (command == null) return false;

            command.Execute(args);

            var viewName = this.Mapping[args.CommandName];

            var nextView = this.GetNextView(viewName);

            this.OnBeforeViewSwitch(nextView, command);

            this.SwitchView(sender as ApplicationViewBase, viewName, args);

            return true;
        }

        public void LoadCommandViewBinding(IDictionary<string, ApplicationViewBase> views,
                                           IDictionary<string, string> mapping,
                                           IDictionary<string, IApplicationContextAccessible> commands)
        {
            this.Views = views;
            this.Commands = commands;
            this.Mapping = mapping;

            this.OnLoadCommandViewBinding();
            this.InitApplicationContext();
        }

        public virtual void OnLoadCommandViewBinding()
        {
            foreach (var model in Models)
            {
                var type = this.GetType();
                var bindOnActionPerformedEventMethod = type.GetMethod("BindOnActionPerformedEvent", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
                
                var method = bindOnActionPerformedEventMethod.MakeGenericMethod(new[] { model.GetType() });

                method.Invoke(this, new object[] {});
            }
        }

        public abstract string InitialViewName { get; }
        public abstract string InitialCommandName { get; }
        public abstract IModel InitialModel { get; }
        public abstract string NotificationViewName { get; }
        public abstract void InitApplicationContext();
        public abstract IList<IModel> Models { get; }
    }
}
