using juip.Commons;
using juip.Events.Handlers;

namespace juip.Controllers
{
    public interface IViewSwitchedInvoker<out TD> where TD : IViewModel, new()
    {
        event ViewSwitchedHandler<TD> ViewSwitched;
    }
}