using sp.jui.Commons;
using sp.jui.Events.Arguments;

namespace sp.jui.Events.Handlers
{
    public delegate void ViewSwitchedMethodDelegate<TD>(ViewSwitchedEventArgs<TD> args) where TD : IModel, new();
}