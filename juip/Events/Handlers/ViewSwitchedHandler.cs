using sp.jui.Commons;
using sp.jui.Controllers;
using sp.jui.Events.Arguments;

namespace sp.jui.Events.Handlers
{
    public delegate void ViewSwitchedHandler<in TD>(IViewSwitchedInvoker<TD> sender, IViewSwitchedEventArgs<TD> args) where TD : IModel, new();
}