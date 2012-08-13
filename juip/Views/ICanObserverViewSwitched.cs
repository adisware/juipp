using juipp.Commons;
using juipp.Controllers;
using juipp.Events.Arguments;

namespace juipp.Views
{
    public interface ICanObserverViewSwitched
    {
        void OnViewModeChanged<T>(IViewSwitchedInvoker<T> sender, IViewSwitchedEventArgs<T> args) where T : IViewModel, new();
    }
}