using juip.Commons;
using juip.Controllers;
using juip.Events.Arguments;

namespace juip.Views
{
    public interface ICanObserverViewSwitched
    {
        void OnViewModeChanged<T>(IViewSwitchedInvoker<T> sender, IViewSwitchedEventArgs<T> args) where T : IViewModel, new();
    }
}