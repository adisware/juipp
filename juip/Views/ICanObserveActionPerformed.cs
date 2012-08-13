using juipp.Commons;
using juipp.Events.Arguments;

namespace juipp.Views
{
    public interface ICanObserveActionPerformed 
    {
        void OnActionPerformed<T>(IActionPerformer<T> sender, ActionPerformedEventArgs<T> args) where T : IViewModel, new();
    }
}