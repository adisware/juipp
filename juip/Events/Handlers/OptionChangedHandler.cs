using juipp.Commons;
using juipp.Events.Arguments;
using juipp.Views;

namespace juipp.Events.Handlers
{
    public delegate void OptionChangedHandler<TD>(SectionViewBase<TD> sender, OptionChangedEventArgs<TD> args)  where TD : IViewModel, new();
}