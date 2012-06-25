using juip.Commons;

namespace juip.Controllers
{
    public interface IDetermineInitialEvent
    {
        string InitialViewName { get; }
        string InitialBehaviorName { get; }
        IViewModel InitialModel { get; }
    }
}