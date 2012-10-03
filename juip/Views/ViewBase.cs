using System.Collections.Generic;
using System.Web.UI;
using adisware.juipp.Commons;
using adisware.juipp.Controllers;
using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Views
{
    public abstract class ViewBase : 
        UserControl, 
        ICanSendBehaviorEvent,  
        ICanChangeMyVisibility,  
        ICanCatchTransition
    {
        public string Reference
        {
            set
            {
                var state = this.ViewState["Reference"];
                if (state != null) this.ViewState.Remove("Reference");
                this.ViewState.Add("Reference", value);
            }
            get
            {
                var state = this.ViewState["Reference"];
                if (state == null) return null;
                return (string)state;
            }
        }

        #region IHideable

        public virtual void Hide()
        {
            if (this.Visible == true) this.Visible = false;
            this.OnVisibilityChanged(false);
        }
        public virtual void Show()
        {
            if (this.Visible == false) this.Visible = true;
            this.OnVisibilityChanged(true);
        }

        #endregion

        public T RetrieveBindingElement<T>()
        {
            var name = typeof(T).FullName;
            if (name != null)
            {
                var bindingItem = this.ViewState[name];
                if (bindingItem == null) return default(T);
                return (T) bindingItem;
            }
            return default(T);
        }
        public void PersistBindingElement<T>(T element)
        {
            var name = typeof(T).FullName;
            if (name != null)
            {
                var bindingItem = this.ViewState[name];
                if (bindingItem != null) this.ViewState.Remove(name);
                this.ViewState.Add(name, element);
            }
        }
        

        public IBehaviorContext BehaviorContext { get; set; }

        public delegate bool FireBehaviorEventDelegate(object behaviorEvent);
        public event VisibilityChangedHandler  VisibilityChanged;

        public void OnVisibilityChanged(bool visibility)
        {
            var handler = VisibilityChanged;
            if (handler != null) handler(this, visibility);
        }
        public bool SendBehaviorEvent<T>(BehaviorEvent<T> behaviorEvent) where T : IViewModel, new()
        {
            var success = false;
            foreach (var fireBehaviorEventDelegate in this.FireBehaviorEventDelegates)
            {
                success = fireBehaviorEventDelegate.Invoke(behaviorEvent);
            }

            return success;
        }

        public virtual void Bind<T>(T viewModel) where T : IViewModel { }
        public virtual void OnAfterTransition<T>(BehaviorEvent<T> behaviorEvent) where T : IViewModel, new() { }
        public virtual void OnCatchTransition<T>(ITransitionEventSender<T> sender, TransitionEvent<T> transitionEvent) where T : IViewModel, new() { }
        public virtual void PropagateChange() { }
        public virtual void Enable() { }
        public virtual void Disable() { }

        protected bool FireBehaviorEvent<T>(BehaviorEventHandler<T> handler, BehaviorEvent<T> behaviorEvent) where T : IViewModel, new()
        {
            if (behaviorEvent == null) return false;
            return handler != null && handler(this as IBehaviorEventSender<T>, behaviorEvent);
        }
        protected readonly IList<FireBehaviorEventDelegate> FireBehaviorEventDelegates = new List<FireBehaviorEventDelegate>();
    }
}