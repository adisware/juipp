using System.Collections.Generic;

using Org.Juipp.Core.Controllers;
using Org.Juipp.Core.Events.Arguments;
using Org.Juipp.Core.Events.Handlers;
using Org.Juipp.Core.ViewModels;

using WebApplication1._layouts.ViewModels;

namespace WebApplication1._layouts.Controllers 
{ 

 
	public partial class Controller : ParentController
    {
        public Controller(ContainerBase containerBase) : base(containerBase) {}
    }
 
	public partial class Default1Controller : ParentController
    {
        public Default1Controller(ContainerBase containerBase) : base(containerBase) {}
    }
 


    public partial class ParentController : ControllerBase
    {
	    public ParentController(ContainerBase containerBase) : base(containerBase) {}
        protected override void OnTransitionEvent<T>(TransitionEvent<T> transitionEvent)  
        {  
              
            base.FireTransitionEvent(transitionEvent as TransitionEvent<Default1ViewModel>, _default1ViewModelViewSwitched);
              
            base.FireTransitionEvent(transitionEvent as TransitionEvent<DefaultViewModel>, _defaultViewModelViewSwitched);
             
        }

        public override IList<IViewModel> Models
        {
            get
            {
                var list = new List<IViewModel>();
                                 list.Add(new Default1ViewModel());
                                 list.Add(new DefaultViewModel());
                                 return list; 
            }
        }
    }


     public partial class ParentController : ITransitionEventSender<Default1ViewModel>
    {
        private TransitionEventHandler<Default1ViewModel> _default1ViewModelViewSwitched;
        event TransitionEventHandler<Default1ViewModel> ITransitionEventSender<Default1ViewModel>.TransitionEventFired
        {
            add { _default1ViewModelViewSwitched += value; }
            remove { if (_default1ViewModelViewSwitched != null) _default1ViewModelViewSwitched -= value; }
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

