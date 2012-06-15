using juip.Commons;
using juip.Events.Arguments;

namespace juip.Behaviors
{
    public interface IBehavior<T> : IApplicationContextAccessible where T : IViewModel, new()
    {
         void Execute(ActionPerformedEventArgs<T> args);
    }
}
