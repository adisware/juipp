using juipp.Events.Handlers;

namespace juipp.Views
{
    public interface IVisibilityChangeInvoker
    {
        event VisibilityChangedHandler VisibilityChanged;
        void OnVisibilityChanged(bool isVisible);
    }
}