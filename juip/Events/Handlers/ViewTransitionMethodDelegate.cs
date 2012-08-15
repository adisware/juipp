using adisware.juipp.Events.Arguments;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Events.Handlers
{
    public delegate void TransitionEventDelegate<TD>(TransitionEvent<TD> transitionEvent) where TD : IViewModel, new();
}