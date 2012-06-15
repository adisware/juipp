using sp.jui.Commons;
using sp.jui.Events.Arguments;

namespace sp.jui.Views
{
    public interface ICanHandleActionPerformed
    {
        bool OnActionPerformed<T>(ActionPerformedEventArgs<T> args) where T : IModel, new();
    }
}