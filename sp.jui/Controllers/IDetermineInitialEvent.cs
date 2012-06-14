using sp.jui.Commons;

namespace sp.jui.Controllers
{
    public interface IDetermineInitialEvent
    {
        string InitialViewName { get; }
        string InitialCommandName { get; }
        IModel InitialModel { get; }
    }
}