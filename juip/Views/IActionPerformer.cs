using juipp.Commons;
using juipp.Events.Handlers;

namespace juipp.Views
{
    public interface IActionPerformer<TD>  where TD : IViewModel, new()
    {
        event ActionPerformedHandler<TD> ActionPerformed;
    }
}