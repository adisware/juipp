using sp.jui.Commons;
using sp.jui.Events.Handlers;

namespace sp.jui.Controllers
{
    public interface IViewSwitchedInvoker<out TD> where TD : IModel, new()
    {
        event ViewSwitchedHandler<TD> ViewSwitched;
    }
}