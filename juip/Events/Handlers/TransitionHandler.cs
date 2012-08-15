using adisware.juipp.Commons;
using adisware.juipp.Controllers;
using adisware.juipp.Events.Arguments;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Events.Handlers
{
    public delegate void TransitionEventHandler<TD>(ITransitionEventSender<TD> sender, TransitionEvent<TD> transitionEvent) where TD : IViewModel, new();
}