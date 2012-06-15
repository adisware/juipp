using juip.Commons;

namespace juip.Views
{
    public interface IParentActionReferable<T>  where T : IViewModel, new()
    {
        void AddActioneableView(IActionPerformer<T> actionPerformer);
    }
}
