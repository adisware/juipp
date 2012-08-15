using adisware.juipp.Commons;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Views
{
    public interface ICanRCollectBehaviorEventSender<T>  where T : IViewModel, new()
    {
        void AddBehaviorEventSender(IBehaviorEventSender<T> behaviorTrigger);
    }
}
