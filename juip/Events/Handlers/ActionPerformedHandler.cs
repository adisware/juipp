using juip.Commons;
using juip.Events.Arguments;
using juip.Views;

namespace juip.Events.Handlers
{
    public delegate bool ActionPerformedHandler<TD>(IActionPerformer<TD> sender, ActionPerformedEventArgs<TD> args) where TD : IViewModel, new();
}