using System;
using adisware.juipp.Commons;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Events.Arguments
{
public class BehaviorEvent<T> where T : IViewModel, new()
{
    public T ViewModel { get; set; }
    public string BehaviorReference { get; set; }
}
}