using sp.jui.Commons;
using sp.jui.Events.Arguments;

namespace sp.jui.Views
{
    public interface ICanObserveActionPerformed 
    {
        void OnActionPerformed<T>(IActionPerformer<T> sender, ActionPerformedEventArgs<T> args) where T : IModel, new();
    }
}