using juip.Commons;
using juip.Events.Arguments;
using sp.jui.Controllers;

namespace juip.Views
{
    public interface ICanObserverViewSwitched
    {
        void OnViewModeChanged<T>(IViewSwitchedInvoker<T> sender, IViewSwitchedEventArgs<T> args) where T : IModel, new();
    }
}