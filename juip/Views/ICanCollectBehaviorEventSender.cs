using adisware.juipp.Commons;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Views
{
    public interface ICanCollectBehaviorEventSender<T>  where T : IViewModel, new()
    {
        void AddBehaviorEventSender(IBehaviorEventSender<T> behaviorTrigger);
    }
}
