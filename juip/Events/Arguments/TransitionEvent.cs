using System;
using adisware.juipp.Commons;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Events.Arguments
{
    public class TransitionEvent<T> where T : IViewModel, new() 
    {
        public BehaviorEvent<T> BehaviorEvent { get; private set; }

        public TransitionEvent(BehaviorEvent<T> behaviorEvent)
        {
            this.BehaviorEvent = behaviorEvent;
        }

        public T ViewModel { get { return this.BehaviorEvent.ViewModel; } set { this.BehaviorEvent.ViewModel = value; } }
        public string ViewReference { get; set; }
        public string PreviousViewReference { get; set; }
    }
}