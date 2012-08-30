using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    [ToolboxData("<{0}:Controller runat=\"server\"></{0}:Controller>")]
    public abstract class ControllerBase :
        WebControl,
        ILoadBehaviorViewBinding,
        IDetermineCurrentViewReference,
        IDetermineModels,
        IBehaviorContext
    {
        protected IDictionary<string, ViewBase> Views;
        protected IDictionary<string, string> Mapping;
        protected IDictionary<string, IBehavior> Behaviors;


        private readonly IDictionary<string, object> _contextValues = new Dictionary<string, object>();

        object IBehaviorContext.this[string key]
        {
            get { return _contextValues.ContainsKey(key) == false ? null : _contextValues[key]; }
            set
            {
                if (_contextValues.ContainsKey(key) == true) _contextValues.Remove(key);
                _contextValues.Add(key, value);
            }
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

        public string CurrentViewReference
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

        private void TransitionView<T>(ICanChangeMyVisibility sender, string viewName, BehaviorEvent<T> behaviorEvent)
            where T : IViewModel, new()
        {
            this.TransitionView(sender, viewName);

            this.FireTransitionEvent(behaviorEvent, this.OnTransitionEvent, viewName);


            //if (sender is IBehaviorEventSender<T>) this.CurrentViewReference = viewName;
        }

        protected void OnInitialBehaviorEventFired<T>(string behaviorName) where T : IViewModel, new()
        {
            this.OnBehaviorEventFired(null, new BehaviorEvent<T>() { BehaviorReference = behaviorName });
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
        }

        private void FireTransitionEvent<T>(BehaviorEvent<T> args, TransitionEventDelegate<T> transitionEventDelegate, string viewName)
            where T : IViewModel, new()
        {
            transitionEventDelegate(new TransitionEvent<T>(args)
            {
                ViewModel = args.ViewModel,
                ViewReference = viewName,
                PreviousViewReference = this.CurrentViewReference
            });

            if (viewName != null) this.CurrentViewReference = viewName;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.Page.IsPostBack) return;
            if (this.CurrentViewReference != null) return;

            var type = this.GetType();
            var onInitialActionPerformed = type.GetMethod("OnInitialBehaviorEventFired", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);

            var attribute = (ControllerAttribute)type.GetCustomAttributes(typeof(ControllerAttribute), false)[0];

            var assembly = type.Assembly;
            var behaviorType = assembly.GetType(attribute.InitialBehaviorFullName);

            if (behaviorType.BaseType == null) throw new ApplicationException("Behavior does not inherit BehaviorBase");



            //For Generic BehaviorBase<>
            var initalModelType = assembly.GetType(attribute.InitialViewModel); //behaviorType.BaseType.GetGenericArguments()[0];
            var method = onInitialActionPerformed.MakeGenericMethod(new[] { initalModelType });
            method.Invoke(this, new object[] { attribute.InitialBehaviorFullName });

            //onInitialActionPerformed.Invoke(this, new object[] {attribute.InitialBehaviorFullName});
        }

        protected void FireTransitionEvent<T>(TransitionEvent<T> transitionEvent, TransitionEventHandler<T> transitionEventHandler)
            where T : IViewModel, new()
        {
            if (transitionEvent == null || transitionEventHandler == null) return;

            transitionEventHandler((ITransitionEventSender<T>)this, transitionEvent);
        }

        protected abstract void OnTransitionEvent<T>(TransitionEvent<T> transitionEvent)
            where T : IViewModel, new();

        protected virtual void OnBeforeBehaviorEvent<T>(IBehaviorEventSender<T> sender, BehaviorEvent<T> behaviorEvent)
            where T : IViewModel, new()
        {
        }

        protected virtual void OnAfterBehaviorEvent<T>(IBehaviorEventSender<T> sender, BehaviorEvent<T> behaviorEvent)
             where T : IViewModel, new()
        {
        }

        protected virtual void OnBeforeTransitionEvent<T>(string viewReference, IExecutableBehavior<T> behavior)
            where T : IViewModel, new()
        {
        }

        protected virtual void OnAfterTransitionEvent<T>(string viewReference, IExecutableBehavior<T> behavior)
            where T : IViewModel, new()
        {
        }


        protected void WireOnBehaviorEventFired<T>()
            where T : IViewModel, new()
        {
            foreach (var view in Views)
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

        public bool OnBehaviorEventFired<T>(IBehaviorEventSender<T> sender, BehaviorEvent<T> behaviorEvent)
            where T : IViewModel, new()
        {
            if (this.Behaviors.ContainsKey(behaviorEvent.BehaviorReference) == false) return false;

            var behavior = this.Behaviors[behaviorEvent.BehaviorReference] as IExecutableBehavior<T>;
            if (behavior == null) return false;

            behavior.BehaviorContext = this;

            this.OnBeforeBehaviorEvent(sender, behaviorEvent);
            behavior.Execute(behaviorEvent);
            this.OnAfterBehaviorEvent(sender, behaviorEvent);

            string viewName = null;

            if (this.Mapping.ContainsKey(behaviorEvent.BehaviorReference))
            {
                viewName = this.Mapping[behaviorEvent.BehaviorReference];
            }

            this.OnBeforeTransitionEvent(viewName, behavior);
            var view = sender as ViewBase;
            this.TransitionView(view, viewName, behaviorEvent);

            this.OnAfterTransitionEvent(viewName, behavior);

            if (viewName != null)
            {
                var next = this.GetNextView(viewName);
                if (next != null) next.OnAfterTransition(behaviorEvent);
            }

            return true;
        }

        public void LoadBehaviorViewBinding(IDictionary<string, ViewBase> views,
                                           IDictionary<string, string> mapping,
                                           IDictionary<string, IBehavior> behaviors)
        {
            this.Views = views;
            this.Behaviors = behaviors;
            this.Mapping = mapping;

            this.OnLoadBehaviorViewBinding();
            this.InitApplicationContext();
        }

        public virtual void OnLoadBehaviorViewBinding()
        {
            foreach (var model in Models)
            {
                var type = this.GetType();
                var wireOnBehaviorEventFiredMethod = type.GetMethod("WireOnBehaviorEventFired", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);

                var method = wireOnBehaviorEventFiredMethod.MakeGenericMethod(new[] { model.GetType() });

                method.Invoke(this, new object[] { });
            }
        }

        public virtual void InitApplicationContext() { }

        public abstract IList<IViewModel> Models { get; }
    }
}
