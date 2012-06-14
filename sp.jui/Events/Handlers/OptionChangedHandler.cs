using sp.jui.Commons;
using sp.jui.Events.Arguments;
using sp.jui.Views;

namespace sp.jui.Events.Handlers
{
    public delegate void OptionChangedHandler<TD>(SectionViewBase<TD> sender, OptionChangedEventArgs<TD> args)  where TD : IModel, new();
}