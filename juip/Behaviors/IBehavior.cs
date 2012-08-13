using juipp.Commons;
using juipp.Events.Arguments;

namespace juipp.Behaviors
{
    public interface IBehavior<T> : IApplicationContextAccessible where T : IViewModel, new()
    {
         void Execute(ActionPerformedEventArgs<T> args);
    }
}
