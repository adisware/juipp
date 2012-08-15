using adisware.juipp.Commons;
using adisware.juipp.Events.Arguments;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Behaviors
{
    public interface IExecutableBehavior<T> : IBehavior where T : IViewModel, new()
    {
        void Execute(BehaviorEvent<T> args);
    }
}