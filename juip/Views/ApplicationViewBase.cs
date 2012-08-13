using System.Collections.Generic;
using System.Web.UI;
using juipp.Commons;
using juipp.Controllers;
using juipp.Events.Arguments;
using juipp.Events.Handlers;

namespace juipp.Views
{
    public abstract class ApplicationViewBase : UserControl, ICanHandleActionPerformed, IDetermineCurrentViewName, IHideable, IVisibilityChangeInvoker, ICanObserverViewSwitched
    {
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

        #region IViewModeable

        private const string ViewModeStateKey = "ViewMode";
        public string CurrentViewName
        {
            set
            {
                var state = this.ViewState[ViewModeStateKey];
                if (state != null) this.ViewState.Remove(ViewModeStateKey);
                this.ViewState.Add(ViewModeStateKey, value);
            }
            get
            {
                var state = this.ViewState[ViewModeStateKey];
                if (state == null) return default(string);
                return (string) state;
            }
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
   


        public event VisibilityChangedHandler  VisibilityChanged;
        public IApplicationContext ActionContext { get; set; }

        public void OnVisibilityChanged(bool isVisible)
        {
            var handler = VisibilityChanged;
            if (handler != null) handler(this, isVisible);
        }
        public bool RaiseActionEvent<T>(ActionPerformedHandler<T> handler, ActionPerformedEventArgs<T> args) where T : IViewModel, new()
        {
            if (args == null) return false;
            return handler != null && handler(this as IActionPerformer<T>, args);
        }
        public virtual void OnViewModeChanged<T>(IViewSwitchedInvoker<T> sender, IViewSwitchedEventArgs<T> args) where T : IViewModel, new() { }
        //public abstract void OnActionPerformed<T>(ActionPerformedEventArgs<T> args) where T : IDataTransferObject, new();

        public virtual void PropagateChange() { }
        public virtual void Enable() { }
        public virtual void Disable() { }

        public delegate bool RaiseActionEventDelegate(object args);

        protected readonly IList<RaiseActionEventDelegate> RaiseActionEventDelegates = new List<RaiseActionEventDelegate>();

        public bool OnActionPerformed<T>(ActionPerformedEventArgs<T> args) where T : IViewModel, new()
        {
            var success = false;
            foreach (var raiseActionEventDelegate in this.RaiseActionEventDelegates)
            {
                success = raiseActionEventDelegate.Invoke(args);
            }

            return success;
        }
    }
}