using juipp.Commons;
using juipp.Events.Arguments;

namespace sp.jui.Events.Handlers
{
    public delegate void ViewSwitchedMethodDelegate<TD>(ViewSwitchedEventArgs<TD> args) where TD : IViewModel, new();
}