using juip.Commons;
using juip.Events.Handlers;

namespace juip.Views
{
    public interface IActionPerformer<TD>  where TD : IModel, new()
    {
        event ActionPerformedHandler<TD> ActionPerformed;
    }
}