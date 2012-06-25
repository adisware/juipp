using System.Collections.Generic;
using juip.Behaviors;
using juip.Views;

namespace juip.Controllers
{
    public interface ILoadBehaviorViewBinding
    {
        void LoadBehaviorViewBinding(
            IDictionary<string, ApplicationViewBase> views,
            IDictionary<string, string> binding,
            IDictionary<string, IApplicationContextAccessible> behaviors);
    }
}