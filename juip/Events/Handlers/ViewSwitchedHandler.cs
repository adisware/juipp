using juip.Commons;
using juip.Controllers;
using juip.Events.Arguments;

namespace juip.Events.Handlers
{
    public delegate void ViewSwitchedHandler<in TD>(IViewSwitchedInvoker<TD> sender, IViewSwitchedEventArgs<TD> args) where TD : IViewModel, new();
}