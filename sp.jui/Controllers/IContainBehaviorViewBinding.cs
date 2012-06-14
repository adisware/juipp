using System.Collections.Generic;
using sp.jui.Behaviors;
using sp.jui.Behaviors;
using sp.jui.Views;

namespace sp.jui.Controllers
{
    public interface IContainBehaviorViewBinding
    {
        IDictionary<string, IApplicationContextAccessible> Behaviors { get; set; } 
        IDictionary<string, ApplicationViewBase> Views { get; set; }
        IDictionary<string, string> Binding { get; set; }
    }
}