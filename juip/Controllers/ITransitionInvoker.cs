using adisware.juipp.Commons;
using adisware.juipp.Events.Handlers;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Controllers
{
    public interface ITransitionEventSender<TD> where TD : IViewModel, new()
    {
        event TransitionEventHandler<TD> TransitionEventFired;
    }
}