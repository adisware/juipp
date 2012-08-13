using juipp.Commons;
using juipp.Events.Handlers;

namespace juipp.Controllers
{
    public interface IViewSwitchedInvoker<out TD> where TD : IViewModel, new()
    {
        event ViewSwitchedHandler<TD> ViewSwitched;
    }
}