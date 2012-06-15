using sp.jui.Commons;
using sp.jui.Events.Arguments;
using sp.jui.Views;

namespace sp.jui.Events.Handlers
{
    public delegate bool ActionPerformedHandler<TD>(IActionPerformer<TD> sender, ActionPerformedEventArgs<TD> args) where TD : IModel, new();
}