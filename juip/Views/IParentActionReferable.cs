using juip.Commons;

namespace juip.Views
{
    public interface IParentActionReferable<T>  where T : IModel, new()
    {
        void AddActioneableView(IActionPerformer<T> actionPerformer);
    }
}
