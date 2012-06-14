using sp.jui.Commons;

namespace sp.jui.Events.Arguments
{

    public interface IViewSwitchedEventArgs<out T> where T : IModel, new()
    {
        string CurrentViewName { get; set; }
        string PreviousViewName { get; set; }
    }
}