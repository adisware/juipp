using juip.Commons;
using juip.Events.Arguments;

namespace juip.Behaviors
{
    public interface IBehavior<T> : IApplicationContextAccessible where T : IModel, new()
    {
         void Execute(ActionPerformedEventArgs<T> args);
    }
}
