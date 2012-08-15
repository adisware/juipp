using adisware.juipp.Controllers;

namespace adisware.juipp.Behaviors
{
    public interface IBehavior
    {
        IBehaviorContext BehaviorContext { get; set; }
    }
}
