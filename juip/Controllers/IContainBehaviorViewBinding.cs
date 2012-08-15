using System.Collections.Generic;
using adisware.juipp.Behaviors;
using adisware.juipp.Commons;
using adisware.juipp.Views;

namespace adisware.juipp.Controllers
{
    public interface IContainBehaviorViewBinding
    {
        IDictionary<string, IBehavior> Behaviors { get; set; }
        IDictionary<string, ViewBase> Views { get; set; }
        IDictionary<string, string> BehaviorBinding { get; set; }
    }
}