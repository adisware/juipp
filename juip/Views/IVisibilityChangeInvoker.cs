using juip.Events.Handlers;

namespace juip.Views
{
    public interface IVisibilityChangeInvoker
    {
        event VisibilityChangedHandler VisibilityChanged;
        void OnVisibilityChanged(bool isVisible);
    }
}