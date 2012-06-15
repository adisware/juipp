using juip.Commons;
using juip.Events.Arguments;
using juip.Views;

namespace juip.Events.Handlers
{
    public delegate void OptionChangedHandler<TD>(SectionViewBase<TD> sender, OptionChangedEventArgs<TD> args)  where TD : IViewModel, new();
}