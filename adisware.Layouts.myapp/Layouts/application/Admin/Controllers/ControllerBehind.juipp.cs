using System.Collections.Generic;

using adisware.juipp.Controllers;
using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.ViewModels;

using adisware.Layouts.application.Admin.ViewModels;

namespace adisware.Layouts.application.Admin.Controllers 
{ 
    public partial class Controller : ControllerBase
    {
        protected override void OnTransitionEvent<T>(TransitionEvent<T> args)  
        {  
             
        }

        public override IList<IViewModel> Models
        {
            get
            {
                var list = new List<IViewModel>();
                                 return list; 
            }
        }
    }


 
} 

