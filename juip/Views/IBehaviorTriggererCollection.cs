using System.Collections.Generic;
using adisware.juipp.Commons;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Views
{
    public interface IBehaviorEventSenderCollection<T> where T : IViewModel, new()
    {
        ICollection<IBehaviorEventSender<T>> BehaviorTriggers { get; }
    }
}
