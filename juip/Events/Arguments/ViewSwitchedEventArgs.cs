using System;
using juip.Commons;

namespace juip.Events.Arguments
{
    public class ViewSwitchedEventArgs<T> : EventArgs, IViewSwitchedEventArgs<T> where T : IModel, new() 
    {
        public ActionPerformedEventArgs<T> ActionPerformedEventArgs { get; private set; }

        public ViewSwitchedEventArgs(ActionPerformedEventArgs<T> internalEventArgs)
        {
            this.ActionPerformedEventArgs = internalEventArgs;
        }

        public T DataItem { get; set; }
        public string CurrentViewName { get; set; }
        public string PreviousViewName { get; set; }
    }
}