using System.Collections.Generic;
using juipp.Behaviors;
using juipp.Views;

namespace juipp.Controllers
{
    public interface IContainBehaviorViewBinding
    {
        IDictionary<string, IApplicationContextAccessible> Behaviors { get; set; } 
        IDictionary<string, ViewBase> Views { get; set; }
        IDictionary<string, string> BehaviorBinding { get; set; }
    }
}