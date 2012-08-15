using adisware.juipp.Commons;
using adisware.juipp.Events.Arguments;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Views
{
    public interface ICanCatchBehaviorEvent
    {
        void OnBehaviorEventReceive<T>(IBehaviorEventSender<T> sender, BehaviorEvent<T> behaviorEvent) where T : IViewModel, new();
    }
}