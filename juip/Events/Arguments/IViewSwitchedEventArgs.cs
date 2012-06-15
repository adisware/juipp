using juip.Commons;

namespace juip.Events.Arguments
{

    public interface IViewSwitchedEventArgs<out T> where T : IModel, new()
    {
        string CurrentViewName { get; set; }
        string PreviousViewName { get; set; }
    }
}