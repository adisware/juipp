using sp.jui.Commons;

namespace sp.jui.Views
{
    public interface IParentActionReferable<T>  where T : IModel, new()
    {
        void AddActioneableView(IActionPerformer<T> actionPerformer);
    }
}
