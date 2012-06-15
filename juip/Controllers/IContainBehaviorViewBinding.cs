using System.Collections.Generic;
using juip.Behaviors;
using juip.Views;

namespace sp.jui.Controllers
{
    public interface IContainBehaviorViewBinding
    {
        IDictionary<string, IApplicationContextAccessible> Behaviors { get; set; } 
        IDictionary<string, ApplicationViewBase> Views { get; set; }
        IDictionary<string, string> BehaviorBinding { get; set; }
    }
}