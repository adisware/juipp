using juip.Commons;
using juip.Events.Arguments;

namespace juip.Views
{
    public interface ICanHandleActionPerformed
    {
        bool OnActionPerformed<T>(ActionPerformedEventArgs<T> args) where T : IModel, new();
    }
}