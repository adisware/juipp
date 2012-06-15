using juip.Commons;
using juip.Events.Handlers;

namespace juip.Views
{
    public interface IActionPerformer<TD>  where TD : IViewModel, new()
    {
        event ActionPerformedHandler<TD> ActionPerformed;
    }
}