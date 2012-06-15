using juip.Commons;
using juip.Events.Handlers;
using sp.jui.Events.Handlers;

namespace sp.jui.Controllers
{
    public interface IViewSwitchedInvoker<out TD> where TD : IViewModel, new()
    {
        event ViewSwitchedHandler<TD> ViewSwitched;
    }
}