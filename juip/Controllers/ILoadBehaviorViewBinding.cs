using System.Collections.Generic;
using juipp.Behaviors;
using juipp.Views;

namespace juipp.Controllers
{
    public interface ILoadBehaviorViewBinding
    {
        void LoadBehaviorViewBinding(
            IDictionary<string, ApplicationViewBase> views,
            IDictionary<string, string> binding,
            IDictionary<string, IApplicationContextAccessible> behaviors);
    }
}