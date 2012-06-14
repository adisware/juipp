using System;
using sp.jui.Commons;

namespace sp.jui.Events.Arguments
{
   

    public class ActionPerformedEventArgs<T> : EventArgs where T : IModel, new()
    {
        internal EventArgs EventArgs { get; private set; }

        public ActionPerformedEventArgs(EventArgs internalEventArgs)
        {
            this.EventArgs = internalEventArgs;
        }
        public T DataItem { get; set; }
        public string CommandName { get; set; }
    }
}