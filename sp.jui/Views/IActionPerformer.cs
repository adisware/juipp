using sp.jui.Commons;
using sp.jui.Events.Handlers;

namespace sp.jui.Views
{
    public interface IActionPerformer<TD>  where TD : IModel, new()
    {
        event ActionPerformedHandler<TD> ActionPerformed;
    }
}