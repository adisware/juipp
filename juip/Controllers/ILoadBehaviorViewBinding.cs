using System.Collections.Generic;
using adisware.juipp.Behaviors;
using adisware.juipp.Commons;
using adisware.juipp.Views;

namespace juipp.Controllers
{
    public interface ILoadBehaviorViewBinding
    {
        void LoadBehaviorViewBinding(
            IDictionary<string, ViewBase> views,
            IDictionary<string, string> binding,
            IDictionary<string, IBehavior> behaviors);
    }
}