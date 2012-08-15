using adisware.juipp.Commons;
using adisware.juipp.Events.Handlers;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Views
{
    public interface IBehaviorEventSender<TD> where TD : IViewModel, new()
    {
        event BehaviorEventHandler<TD> BehaviorEventFired;
    }
}