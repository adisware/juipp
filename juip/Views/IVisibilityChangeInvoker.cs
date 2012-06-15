using sp.jui.Events.Handlers;

namespace sp.jui.Views
{
    public interface IVisibilityChangeInvoker
    {
        event VisibilityChangedHandler VisibilityChanged;
        void OnVisibilityChanged(bool isVisible);
    }
}