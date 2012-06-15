using sp.jui.Commons;

namespace sp.jui.Controllers
{
    public interface IDetermineInitialEvent
    {
        string InitialViewName { get; }
        string InitialBehaviorName { get; }
        IModel InitialModel { get; }
    }
}