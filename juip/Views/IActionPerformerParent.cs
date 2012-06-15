using System.Collections.Generic;
using juip.Commons;

namespace juip.Views
{
    public interface IActionPerformerParent<T> where T : IModel, new()
    {
        ICollection<IActionPerformer<T>> ChildActionPerformer { get; }
    }
}
