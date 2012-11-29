using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.Views;
using ItemTemplate1.ViewModels;

namespace ItemTemplate1.Views 
{
   
    public partial class View : ViewBase {}
    
    public static class ViewReference
    {
             public static string DefaultView = "DefaultView";
                 }

     
        public partial class View : IBehaviorEventSender<DefaultViewModel> 
        {
            private BehaviorEventHandler<DefaultViewModel> _defaultViewModelBehaviorEventFired;
            event BehaviorEventHandler<DefaultViewModel> IBehaviorEventSender<DefaultViewModel>.BehaviorEventFired
            {
                add
                {
                    _defaultViewModelBehaviorEventFired += value;
                    base.FireBehaviorEventDelegates.Add(args => base.FireBehaviorEvent(_defaultViewModelBehaviorEventFired, args as BehaviorEvent<DefaultViewModel>));
                }
                remove { if (_defaultViewModelBehaviorEventFired != null) _defaultViewModelBehaviorEventFired -= value; }
            }
        }
    } 

