using adisware.juipp.Events.Handlers;

namespace adisware.juipp.Views
{
    public interface IVisibilityChangedInvoker
    {
        event VisibilityChangedHandler VisibilityChanged;
        void OnVisibilityChanged(bool isVisible);
    }
}