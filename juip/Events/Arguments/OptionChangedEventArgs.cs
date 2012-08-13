using System;

namespace juipp.Events.Arguments
{
    public class OptionChangedEventArgs<TD> : EventArgs
    {
        internal EventArgs EventArgs { get; private set; }

        public OptionChangedEventArgs(EventArgs internalEventArgs)
        {
            this.EventArgs = internalEventArgs;
        }

        public TD Data { get; set; }
    }
}