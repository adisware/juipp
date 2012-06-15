using System;
using juip.Commons;

namespace juip.Events.Arguments
{
   

    public class ActionPerformedEventArgs<T> : EventArgs where T : IViewModel, new()
    {
        internal EventArgs EventArgs { get; private set; }

        public ActionPerformedEventArgs(EventArgs internalEventArgs)
        {
            this.EventArgs = internalEventArgs;
        }
        public T DataItem { get; set; }
        public string BehaviorName { get; set; }
    }
}