using sp.jui.Commons;
using sp.jui.Controllers;
using sp.jui.Events.Arguments;

namespace sp.jui.Views
{
    public interface ICanObserverViewSwitched
    {
        void OnViewModeChanged<T>(IViewSwitchedInvoker<T> sender, IViewSwitchedEventArgs<T> args) where T : IModel, new();
    }
}