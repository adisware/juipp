using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.Views;
using adisware.juipp.Web._layouts.app.ViewModels;

namespace adisware.juipp.Web._layouts.app.Views 
{
   
    public partial class View : ViewBase {}
    
    public static class ViewReference
    {
             public const string HomeAdminView = "HomeAdminView";
             public const string HomeView = "HomeView";
             public const string MyView = "MyView";
             public const string StudentProfileView = "StudentProfileView";
             }



	 
        public partial class HomeAdminView : View {}
     
        public partial class HomeView : View {}
     
        public partial class MyView : View {}
     
        public partial class StudentProfileView : View {}
    
     
        public partial class View : IBehaviorEventSender<MyViewModel> 
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
     
        public partial class View : IBehaviorEventSender<StudentViewModel> 
        {
            private BehaviorEventHandler<StudentViewModel> _studentViewModelBehaviorEventFired;
            event BehaviorEventHandler<StudentViewModel> IBehaviorEventSender<StudentViewModel>.BehaviorEventFired
            {
                add
                {
                    _studentViewModelBehaviorEventFired += value;
                    base.FireBehaviorEventDelegates.Add(args => base.FireBehaviorEvent(_studentViewModelBehaviorEventFired, args as BehaviorEvent<StudentViewModel>));
                }
                remove { if (_studentViewModelBehaviorEventFired != null) _studentViewModelBehaviorEventFired -= value; }
            }
        }
     
        public partial class View : IBehaviorEventSender<UserViewModel> 
        {
            private BehaviorEventHandler<UserViewModel> _userViewModelBehaviorEventFired;
            event BehaviorEventHandler<UserViewModel> IBehaviorEventSender<UserViewModel>.BehaviorEventFired
            {
                add
                {
                    _userViewModelBehaviorEventFired += value;
                    base.FireBehaviorEventDelegates.Add(args => base.FireBehaviorEvent(_userViewModelBehaviorEventFired, args as BehaviorEvent<UserViewModel>));
                }
                remove { if (_userViewModelBehaviorEventFired != null) _userViewModelBehaviorEventFired -= value; }
            }
        }
    } 

