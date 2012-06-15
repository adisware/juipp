using juip.Commons;
using juip.Events.Arguments;
using sp.jui.Controllers;

namespace juip.Events.Handlers
{
    public delegate void ViewSwitchedHandler<in TD>(IViewSwitchedInvoker<TD> sender, IViewSwitchedEventArgs<TD> args) where TD : IModel, new();
}