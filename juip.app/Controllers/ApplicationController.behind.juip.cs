using System.Collections.Generic;
using juip.Commons;
using juip.Events.Arguments;
using juip.Events.Handlers;
using TargetName@juip.ViewModels;
using juip.Controllers;

namespace TargetName@juip.Controllers
{    
    public partial class ApplicationController : ControllerBase
    {
        protected override void OnViewSwitch<T>(ViewSwitchedEventArgs<T> args)  
        {  
              
            base.FireViewSwitched(args as ViewSwitchedEventArgs<CourseViewModel>, _courseViewModelViewSwitched);
              
            base.FireViewSwitched(args as ViewSwitchedEventArgs<RegistrationViewModel>, _registrationViewModelViewSwitched);
              
            base.FireViewSwitched(args as ViewSwitchedEventArgs<StudentViewModel>, _studentViewModelViewSwitched);
             
        }

        public override IList<IViewModel> Models
        {
            get
            {
                var list = new List<IViewModel>();
                                 list.Add(new CourseViewModel());
                                 list.Add(new RegistrationViewModel());
                                 list.Add(new StudentViewModel());
                                 return list; 
            }
        }
    }


     public partial class ApplicationController : IViewSwitchedInvoker<CourseViewModel>
    {
        private ViewSwitchedHandler<CourseViewModel> _courseViewModelViewSwitched;
        event ViewSwitchedHandler<CourseViewModel> IViewSwitchedInvoker<CourseViewModel>.ViewSwitched
        {
            add { _courseViewModelViewSwitched += value; }
            remove { if (_courseViewModelViewSwitched != null) _courseViewModelViewSwitched -= value; }
        }
    }
     public partial class ApplicationController : IViewSwitchedInvoker<RegistrationViewModel>
    {
        private ViewSwitchedHandler<RegistrationViewModel> _registrationViewModelViewSwitched;
        event ViewSwitchedHandler<RegistrationViewModel> IViewSwitchedInvoker<RegistrationViewModel>.ViewSwitched
        {
            add { _registrationViewModelViewSwitched += value; }
            remove { if (_registrationViewModelViewSwitched != null) _registrationViewModelViewSwitched -= value; }
        }
    }
     public partial class ApplicationController : IViewSwitchedInvoker<StudentViewModel>
    {
        private ViewSwitchedHandler<StudentViewModel> _studentViewModelViewSwitched;
        event ViewSwitchedHandler<StudentViewModel> IViewSwitchedInvoker<StudentViewModel>.ViewSwitched
        {
            add { _studentViewModelViewSwitched += value; }
            remove { if (_studentViewModelViewSwitched != null) _studentViewModelViewSwitched -= value; }
        }
    }
 
} 

