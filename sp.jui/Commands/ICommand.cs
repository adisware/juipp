using sp.jui.Commons;
using sp.jui.Events.Arguments;

namespace sp.jui.Commands
{
    public interface ICommand<T> : IApplicationContextAccessible where T : IModel, new()
    {
         void Execute(ActionPerformedEventArgs<T> args);
    }
}
