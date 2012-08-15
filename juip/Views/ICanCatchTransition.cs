using adisware.juipp.Commons;
using adisware.juipp.Controllers;
using adisware.juipp.Events.Arguments;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Views
{
    public interface ICanCatchTransition
    {
        void OnCatchTransition<T>(ITransitionEventSender<T> sender, TransitionEvent<T> args) where T : IViewModel, new();
    }
}