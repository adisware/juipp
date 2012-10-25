/* The MIT License (MIT)
 * Copyright (c) 2012-2013 Adisware (Natnael Gebremariam)
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
 * DEALINGS IN THE SOFTWARE.
 * */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using adisware.juipp.Behaviors;
using adisware.juipp.Commons;
using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.ViewModels;
using adisware.juipp.Views;

namespace adisware.juipp.Controllers
{
    public abstract class ControllerBase :
        WebControl,
        ILoadBehaviorViewBinding,
        IDetermineModels,
        IBehaviorContext
    {
        protected IDictionary<string, ViewBase> Views;
        protected IDictionary<string, string> BehaviorBinding;
        protected IDictionary<string, string> ViewControllerBinding;
        protected IDictionary<string, IBehavior> Behaviors;
        protected ContainerBase ContainerBase;
        public ScriptManager ScriptManager { get; set; }

        protected Stack<String> ViewHistory
        {
            get
            {
                var history = this.RetrieveBindingElement("ViewHistory");
                return history == null ? new Stack<string>() : history as Stack<string>;
            }
            set { this.PersistBindingElement("ViewHistory", value);}
        }

        protected ControllerBase(ContainerBase containerBase)
        {
            ContainerBase = containerBase;
        }

        #region IBehaviorContext Members

        object IBehaviorContext.this[string key]
        {
            get { return (ContainerBase as IBehaviorContext)[key]; }
            set { (ContainerBase as IBehaviorContext)[key] = value; }
        }

        #endregion

        private string CurrentViewReference
        {
            set
            {
                var state = this.ViewState["CurrentViewReference"];
                if (state != null) this.ViewState.Remove("CurrentViewReference");
                this.ViewState.Add("CurrentViewReference", value);
            }
            get
            {
                var state = this.ViewState["CurrentViewReference"];
                if (state == null) return null;
                return (string)state;
            }
        }
        private void TransitionView<T>(ICanChangeMyVisibility sender, string viewName, BehaviorEvent<T> behaviorEvent)  where T : IViewModel, new()
        {
            this.TransitionView(sender, viewName);

            this.FireTransitionEvent(behaviorEvent, this.OnTransitionEvent, viewName);


            //if (sender is IBehaviorEventSender<T>) this.CurrentViewReference = viewName;
        }
        private ViewBase GetNextView(string viewName)
        {
            var nextView = Views[viewName];
            nextView.Reference = viewName;
            return nextView;
        }
        private void TransitionView(ICanChangeMyVisibility sender, string viewName)
        {
            if (viewName == null) return;
            var nextView = this.GetNextView(viewName);
            if (sender != null && !sender.Equals(nextView))
            {
                sender.Hide();
            }
            nextView.Show();

            if (string.IsNullOrEmpty(viewName) == false)
            {
                var viewHistory = this.ViewHistory;
                viewHistory.Push(viewName);
                this.ViewHistory = viewHistory;
            }
        }
        private static void BindViewModel(Control view, IViewModel viewModel)
        {
            if (viewModel == null) return;

            var viewType = view.GetType();
            var modelType = viewModel.GetType();

            var bind = viewType.GetMethods().FirstOrDefault(
                m =>
                    m.Name == "Bind"
                    && m.GetParameters().FirstOrDefault() != null
                    && m.GetParameters()[0].ParameterType == modelType);

            if (bind != null) bind.Invoke(view, new object[] { viewModel });

            foreach (var control in view.Controls.OfType<ViewBase>())
            {
                BindViewModel(control as ViewBase, viewModel);
            }
        }
        private void FireTransitionEvent<T>(BehaviorEvent<T> args, TransitionEventDelegate<T> transitionEventDelegate, string viewName)  where T : IViewModel, new()
        {
            var transitionEvent = new TransitionEvent<T>(args)
            {
                ViewModel = args.ViewModel,
                ViewReference = viewName,
                PreviousViewReference = this.CurrentViewReference
            };
            transitionEventDelegate(transitionEvent);

            if (viewName != null) this.CurrentViewReference = viewName;


            this.ScriptManager = ScriptManager.GetCurrent(this.Page);
            if (this.ScriptManager != null
                && this.ScriptManager.IsInAsyncPostBack
                && this.ScriptManager.EnableHistory
                && string.IsNullOrEmpty(viewName) == false)
            {
                this.ScriptManager.AddHistoryPoint(new NameValueCollection()
                                                       {
                                                           {"pv", transitionEvent.PreviousViewReference}
                                                       }, transitionEvent.PreviousViewReference);
            }

        }
        private bool OnBehaviorEventFired<T>(IBehaviorEventSender<T> sender, BehaviorEvent<T> behaviorEvent) where T : IViewModel, new()
        {
            this.OnBeforeBehaviorLookup(behaviorEvent);
            if (this.Behaviors.ContainsKey(behaviorEvent.BehaviorReference) == false) return false;

            var behavior = this.Behaviors[behaviorEvent.BehaviorReference] as IExecutableBehavior<T>;
            if (behavior == null) return false;

            behavior.BehaviorContext = this;

            this.OnBeforeBehaviorEvent(sender, behaviorEvent);
            this.OnBehaviorEvent(behavior, behaviorEvent);
            this.OnAfterBehaviorEvent(sender, behaviorEvent);

            string viewName = null;

            if (this.BehaviorBinding.ContainsKey(behaviorEvent.BehaviorReference))
            {
                viewName = this.BehaviorBinding[behaviorEvent.BehaviorReference];
            }

            this.OnBeforeTransitionEvent(viewName, behavior);
            var view = sender as ViewBase;
            if (view != null) view.BehaviorContext = this;

            this.TransitionView(view, viewName, behaviorEvent);

            this.OnAfterTransitionEvent(viewName, behavior);



            if (viewName == null && sender is ViewBase)
            {
                BindViewModel(sender as ViewBase, behaviorEvent.ViewModel);
            }
            else if (viewName != null)
            {
                var next = this.GetNextView(viewName);
                if (next != null)
                {
                    next.OnAfterTransition(behaviorEvent);
                    foreach (var sub in next.Controls.OfType<ViewBase>())
                    {
                        sub.BehaviorContext = next.BehaviorContext;
                        sub.OnAfterTransition(behaviorEvent);
                    }

                    BindViewModel(next, behaviorEvent.ViewModel);
                }
            }

            return true;
        }

        protected T RetrieveBindingElement<T>()
        {
            var name = typeof(T).FullName;
            if (name != null)
            {
                var bindingItem = this.ViewState[name];
                if (bindingItem == null) return default(T);
                return (T)bindingItem;
            }
            return default(T);
        }
        protected void PersistBindingElement<T>(T element)
        {
            var name = typeof(T).FullName;
            if (name != null)
            {
                var bindingItem = this.ViewState[name];
                if (bindingItem != null) this.ViewState.Remove(name);
                this.ViewState.Add(name, element);
            }
        }
        protected object RetrieveBindingElement(string key)
        {
            var bindingItem = this.ViewState[key];
            return bindingItem;
        }
        protected void PersistBindingElement(string key, object element)
        {
            var bindingItem = this.ViewState[key];
            if (bindingItem != null) this.ViewState.Remove(key);
            this.ViewState.Add(key, element);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.ScriptManager = ScriptManager.GetCurrent(this.Page);
            if (this.ScriptManager != null)
            {
                this.ScriptManager.Navigate += this.ScriptManagerNavigate;

            }
        }

        protected virtual void ScriptManagerNavigate(object sender, HistoryEventArgs e)
        {
            
            if (e.State.AllKeys.Contains("pv") == false) return;

            this.TransitionView(this.Views[this.CurrentViewReference], e.State["pv"]);
            this.CurrentViewReference = e.State["pv"];
        }
        protected void OnInitialBehaviorEventFired<T>(string behaviorName) where T : IViewModel, new()
        {
            this.OnBehaviorEventFired(null,
                new BehaviorEvent<T>()
                {
                    BehaviorReference = behaviorName
                });
        }
        protected void OnLoadBehaviorViewBinding()
        {
            foreach (var model in Models)
            {
                var type = this.GetType();
                var wireOnBehaviorEventFiredMethod = type.GetMethod("WireOnBehaviorEventFired", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);

                var method = wireOnBehaviorEventFiredMethod.MakeGenericMethod(new[] { model.GetType() });

                method.Invoke(this, new object[] { });
            }

        }
        protected void WireViewEvents()
        {
            foreach (var view in Views.Where(view => this.ViewControllerBinding[view.Key] == this.ID))
            {
                view.Value.BackTriggered += this.ValueBackTriggered;
            }
        }
        protected void FireTransitionEvent<T>(TransitionEvent<T> transitionEvent, TransitionEventHandler<T> transitionEventHandler) where T : IViewModel, new()
        {
            if (transitionEvent == null || transitionEventHandler == null) return;

            transitionEventHandler((ITransitionEventSender<T>)this, transitionEvent);
        }
        protected void WireOnBehaviorEventFired<T>() where T : IViewModel, new()
        {
            foreach (var view in Views.Where(view => this.ViewControllerBinding[view.Key] == this.ID))
            {
                view.Value.BehaviorContext = this;

                if (view.Value is IBehaviorEventSender<T>)
                {
                    var actionPerformer = ((IBehaviorEventSender<T>)view.Value);

                    actionPerformer.BehaviorEventFired -= this.OnBehaviorEventFired;
                    actionPerformer.BehaviorEventFired += this.OnBehaviorEventFired;

                    if (view.Value is IBehaviorEventSenderCollection<T>)
                    {
                        var parent = (IBehaviorEventSenderCollection<T>)view.Value;
                        foreach (var c in parent.BehaviorTriggers)
                        {
                            c.BehaviorEventFired -= this.OnBehaviorEventFired;
                            c.BehaviorEventFired += this.OnBehaviorEventFired;
                        }
                    }
                }

                var listenerView = view.Value as ICanCatchTransition;
                ((ITransitionEventSender<T>)this).TransitionEventFired += listenerView.OnCatchTransition;
            }
        }
        protected void ValueBackTriggered(object sender, EventArgs e)
        {
            var viewHistory = this.ViewHistory;
            viewHistory.Pop(); //pop the current
            this.ViewHistory = viewHistory;
            this.TransitionView(sender as ICanChangeMyVisibility, ViewHistory.Pop()); //pop the previous one
        }

        protected virtual void InitBehaviorContext() { }
        protected virtual void OnBeforeBehaviorEvent<T>(IBehaviorEventSender<T> sender, BehaviorEvent<T> behaviorEvent) where T : IViewModel, new()
        {
        }
        protected virtual void OnBeforeBehaviorLookup<T>(BehaviorEvent<T> behaviorEvent) where T : IViewModel, new()
        {
        }
        protected virtual void OnAfterBehaviorEvent<T>(IBehaviorEventSender<T> sender, BehaviorEvent<T> behaviorEvent) where T : IViewModel, new()
        {
        }
        protected virtual void OnBehaviorEvent<T>(IExecutableBehavior<T> executableBehavior, BehaviorEvent<T> behaviorEvent) where T : IViewModel, new()
        {
            executableBehavior.Execute(behaviorEvent);
        }
        protected virtual void OnBeforeTransitionEvent<T>(string viewReference, IExecutableBehavior<T> behavior) where T : IViewModel, new()
        {
        }
        protected virtual void OnAfterTransitionEvent<T>(string viewReference, IExecutableBehavior<T> behavior) where T : IViewModel, new()
        {
        }

        protected abstract void OnTransitionEvent<T>(TransitionEvent<T> transitionEvent) where T : IViewModel, new();
        public abstract IList<IViewModel> Models { get; }

        public bool FireBehaviorEvent<T>(BehaviorEvent<T> behaviorEvent) where T : IViewModel, new()
        {
            return this.OnBehaviorEventFired(null, behaviorEvent);
        }
        public void LoadBehaviorViewBinding(
            IDictionary<string, ViewBase> views,
            IDictionary<string, IBehavior> behaviors,
            IDictionary<string, string> behaviorBinding,
            IDictionary<string, string> viewControllerBinding)
        {
            this.Views = views;
            this.Behaviors = behaviors;
            this.BehaviorBinding = behaviorBinding;
            this.ViewControllerBinding = viewControllerBinding;
            this.WireViewEvents();
            this.OnLoadBehaviorViewBinding();
            this.InitBehaviorContext();
        }
    }
}
