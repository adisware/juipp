using juipp.Commons;

namespace juipp.Controllers
{
    public interface IDetermineInitialEvent
    {
        string InitialViewName { get; }
        string InitialBehaviorName { get; }
        IViewModel InitialModel { get; }
    }
}