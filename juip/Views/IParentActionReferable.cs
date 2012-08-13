using juipp.Commons;

namespace juipp.Views
{
    public interface IParentActionReferable<T>  where T : IViewModel, new()
    {
        void AddActioneableView(IActionPerformer<T> actionPerformer);
    }
}
