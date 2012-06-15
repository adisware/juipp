using juip.Commons;
using juip.Events.Arguments;

namespace sp.jui.Events.Handlers
{
    public delegate void ViewSwitchedMethodDelegate<TD>(ViewSwitchedEventArgs<TD> args) where TD : IModel, new();
}