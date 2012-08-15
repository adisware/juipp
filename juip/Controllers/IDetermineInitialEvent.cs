using adisware.juipp.Commons;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Controllers
{
    public interface IDetermineInitialEvent
    {
        string InitialViewName { get; }
        string InitialBehaviorName { get; }
        IViewModel InitialModel { get; }
    }
}