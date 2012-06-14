using System.Collections.Generic;
using sp.jui.Commons;

namespace sp.jui.Views
{
    public interface IActionPerformerParent<T> where T : IModel, new()
    {
        ICollection<IActionPerformer<T>> ChildActionPerformer { get; }
    }
}
