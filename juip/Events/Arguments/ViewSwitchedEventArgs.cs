using System;
using juipp.Commons;

namespace juipp.Events.Arguments
{
    public class ViewSwitchedEventArgs<T> : EventArgs, IViewSwitchedEventArgs<T> where T : IViewModel, new() 
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