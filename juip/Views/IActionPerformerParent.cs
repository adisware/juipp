using System.Collections.Generic;
using juipp.Commons;

namespace juipp.Views
{
    public interface IActionPerformerParent<T> where T : IViewModel, new()
    {
        ICollection<IActionPerformer<T>> ChildActionPerformer { get; }
    }
}
