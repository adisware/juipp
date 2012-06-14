using System.Collections.Generic;
using sp.jui.Behaviors;
using sp.jui.Behaviors;
using sp.jui.Views;

namespace sp.jui.Controllers
{
    public interface ILoadBehaviorViewBinding
    {
        void LoadBehaviorViewBinding(
            IDictionary<string, ApplicationViewBase> views,
            IDictionary<string, string> binding,
            IDictionary<string, IApplicationContextAccessible> behaviors);
    }
}