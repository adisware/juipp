using juip.Commons;

namespace sp.jui.Controllers
{
    public interface IDetermineInitialEvent
    {
        string InitialViewName { get; }
        string InitialBehaviorName { get; }
        IViewModel InitialModel { get; }
    }
}