using juipp.Commons;
using juipp.Events.Arguments;

namespace juipp.Views
{
    public interface ICanHandleActionPerformed
    {
        bool OnActionPerformed<T>(ActionPerformedEventArgs<T> args) where T : IViewModel, new();
    }
}