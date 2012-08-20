using System.Collections.Generic;

using adisware.juipp.Controllers;
using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.ViewModels;

using adisware.Layouts.juipp.ViewModels;

namespace adisware.Layouts.juipp.Controllers 
{ 
    public partial class ApplicationController : ControllerBase
    {
        protected override void OnTransitionEvent<T>(TransitionEvent<T> args)  
        {  
              
            base.FireViewSwitched(args as TransitionEvent<MyViewModel>, _myViewModelViewSwitched);
             
        }

        public override IList<IViewModel> Models
        {
            get
            {
                var list = new List<IViewModel>();
                                 list.Add(new MyViewModel());
                                 return list; 
            }
        }
    }


     public partial class ApplicationController : ITransitionEventSender<MyViewModel>
    {
        private TransitionEventHandler<MyViewModel> _myViewModelViewSwitched;
        event TransitionEventHandler<MyViewModel> ITransitionEventSender<MyViewModel>.TransitionEventFired
        {
            add { _myViewModelViewSwitched += value; }
            remove { if (_myViewModelViewSwitched != null) _myViewModelViewSwitched -= value; }
        }
    }
 
} 

