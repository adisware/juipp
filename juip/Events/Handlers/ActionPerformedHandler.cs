using juipp.Commons;
using juipp.Events.Arguments;
using juipp.Views;

namespace juipp.Events.Handlers
{
    public delegate bool ActionPerformedHandler<TD>(IActionPerformer<TD> sender, ActionPerformedEventArgs<TD> args) where TD : IViewModel, new();
}