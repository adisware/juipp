using juip.Commons;
using juip.Events.Arguments;

namespace juip.Views
{
    public interface ICanObserveActionPerformed 
    {
        void OnActionPerformed<T>(IActionPerformer<T> sender, ActionPerformedEventArgs<T> args) where T : IModel, new();
    }
}