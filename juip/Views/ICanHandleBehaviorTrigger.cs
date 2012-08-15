using adisware.juipp.Commons;
using adisware.juipp.Events.Arguments;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Views
{
    public interface ICanSendBehaviorEvent
    {
        bool SendBehaviorEvent<T>(BehaviorEvent<T> args) where T : IViewModel, new();
    }
}