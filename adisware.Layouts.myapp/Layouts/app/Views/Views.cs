using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.Views;
using adisware.Layouts.app.ViewModels;

namespace adisware.Layouts.app.Views 
{
   
    public partial class Views : ViewBase {}
    
    public static class ViewReference
    {
             }



	
     
        public partial class Views : IBehaviorEventSender<MyViewModel> 
        {
            private BehaviorEventHandler<MyViewModel> _myViewModelBehaviorEventFired;
            event BehaviorEventHandler<MyViewModel> IBehaviorEventSender<MyViewModel>.BehaviorEventFired
            {
                add
                {
                    _myViewModelBehaviorEventFired += value;
                    base.FireBehaviorEventDelegates.Add(args => base.FireBehaviorEvent(_myViewModelBehaviorEventFired, args as BehaviorEvent<MyViewModel>));
                }
                remove { if (_myViewModelBehaviorEventFired != null) _myViewModelBehaviorEventFired -= value; }
            }
        }
     
        public partial class Views : IBehaviorEventSender<ViewModels> 
        {
            private BehaviorEventHandler<ViewModels> _viewModelsBehaviorEventFired;
            event BehaviorEventHandler<ViewModels> IBehaviorEventSender<ViewModels>.BehaviorEventFired
            {
                add
                {
                    _viewModelsBehaviorEventFired += value;
                    base.FireBehaviorEventDelegates.Add(args => base.FireBehaviorEvent(_viewModelsBehaviorEventFired, args as BehaviorEvent<ViewModels>));
                }
                remove { if (_viewModelsBehaviorEventFired != null) _viewModelsBehaviorEventFired -= value; }
            }
        }
     
        public partial class Views : IBehaviorEventSender<ViewModels> 
        {
            private BehaviorEventHandler<ViewModels> _viewModelsBehaviorEventFired;
            event BehaviorEventHandler<ViewModels> IBehaviorEventSender<ViewModels>.BehaviorEventFired
            {
                add
                {
                    _viewModelsBehaviorEventFired += value;
                    base.FireBehaviorEventDelegates.Add(args => base.FireBehaviorEvent(_viewModelsBehaviorEventFired, args as BehaviorEvent<ViewModels>));
                }
                remove { if (_viewModelsBehaviorEventFired != null) _viewModelsBehaviorEventFired -= value; }
            }
        }
    } 

