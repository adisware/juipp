using System.Collections.Generic;

using adisware.juipp.Controllers;
using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.ViewModels;

using adisware.juipp.Web._layouts.app.ViewModels;

namespace adisware.juipp.Web._layouts.app.Controllers 
{ 
    public partial class Controller : ControllerBase
    {
        protected override void OnTransitionEvent<T>(TransitionEvent<T> args)  
        {  
              
            base.FireTransitionEvent(args as TransitionEvent<MyViewModel>, _myViewModelViewSwitched);
              
            base.FireTransitionEvent(args as TransitionEvent<StudentViewModel>, _studentViewModelViewSwitched);
             
        }

        public override IList<IViewModel> Models
        {
            get
            {
                var list = new List<IViewModel>();
                                 list.Add(new MyViewModel());
                                 list.Add(new StudentViewModel());
                                 return list; 
            }
        }
    }


     public partial class Controller : ITransitionEventSender<MyViewModel>
    {
        private TransitionEventHandler<MyViewModel> _myViewModelViewSwitched;
        event TransitionEventHandler<MyViewModel> ITransitionEventSender<MyViewModel>.TransitionEventFired
        {
            add { _myViewModelViewSwitched += value; }
            remove { if (_myViewModelViewSwitched != null) _myViewModelViewSwitched -= value; }
        }
    }
     public partial class Controller : ITransitionEventSender<StudentViewModel>
    {
        private TransitionEventHandler<StudentViewModel> _studentViewModelViewSwitched;
        event TransitionEventHandler<StudentViewModel> ITransitionEventSender<StudentViewModel>.TransitionEventFired
        {
            add { _studentViewModelViewSwitched += value; }
            remove { if (_studentViewModelViewSwitched != null) _studentViewModelViewSwitched -= value; }
        }
    }
 
} 

