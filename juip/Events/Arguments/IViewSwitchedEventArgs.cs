using juip.Commons;

namespace juip.Events.Arguments
{

    public interface IViewSwitchedEventArgs<out T> where T : IViewModel, new()
    {
        string CurrentViewName { get; set; }
        string PreviousViewName { get; set; }
    }
}