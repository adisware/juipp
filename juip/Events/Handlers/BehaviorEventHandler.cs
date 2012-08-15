using adisware.juipp.Events.Arguments;
using adisware.juipp.ViewModels;
using adisware.juipp.Views;

namespace adisware.juipp.Events.Handlers
{
    public delegate bool BehaviorEventHandler<TD>(IBehaviorEventSender<TD> sender, BehaviorEvent<TD> args) where TD : IViewModel, new();
}