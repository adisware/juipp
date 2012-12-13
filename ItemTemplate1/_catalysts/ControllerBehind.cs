using System.Collections.Generic;

using adisware.juipp.Controllers;
using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.ViewModels;

using ItemTemplate1.ViewModels;

namespace ItemTemplate1.Controllers 
{ 

 
	public partial class Controller : ParentController
    {
        public Controller(ContainerBase containerBase) : base(containerBase) {}
    }
 


    public partial class ParentController : ControllerBase
    {
	    public ParentController(ContainerBase containerBase) : base(containerBase) {}
        protected override void OnTransitionEvent<T>(TransitionEvent<T> transitionEvent)  
        {  
              
            base.FireTransitionEvent(transitionEvent as TransitionEvent<DefaultViewModel>, _defaultViewModelViewSwitched);
             
        }

        public override IList<IViewModel> Models
        {
            get
            {
                var list = new List<IViewModel>();
                                 list.Add(new DefaultViewModel());
                                 return list; 
            }
        }
    }


     public partial class ParentController : ITransitionEventSender<DefaultViewModel>
    {
        private TransitionEventHandler<DefaultViewModel> _defaultViewModelViewSwitched;
        event TransitionEventHandler<DefaultViewModel> ITransitionEventSender<DefaultViewModel>.TransitionEventFired
        {
            add { _defaultViewModelViewSwitched += value; }
            remove { if (_defaultViewModelViewSwitched != null) _defaultViewModelViewSwitched -= value; }
        }
    }
 
} 

