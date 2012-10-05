using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.Views;
using adisware.juipp.Web._layouts.app.ViewModels;

namespace adisware.juipp.Web._layouts.app.Views 
{
   
    public partial class View : ViewBase {}
    
    public static class ViewReference
    {
             public const string MyView = "adisware.juipp.Web._layouts.app.Views.MyView";
             public const string StudentProfileView = "adisware.juipp.Web._layouts.app.Views.StudentProfileView";
                 }



	 
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
    } 

