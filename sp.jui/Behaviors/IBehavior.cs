using sp.jui.Behaviors;
using sp.jui.Commons;
using sp.jui.Events.Arguments;

namespace sp.jui.Behaviors
{
    public interface IBehavior<T> : IApplicationContextAccessible where T : IModel, new()
    {
         void Execute(ActionPerformedEventArgs<T> args);
    }
}
