using juipp.Commons;
using juipp.Controllers;
using juipp.Events.Arguments;

namespace juipp.Events.Handlers
{
    public delegate void ViewSwitchedHandler<in TD>(IViewSwitchedInvoker<TD> sender, IViewSwitchedEventArgs<TD> args) where TD : IViewModel, new();
}