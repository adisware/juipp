using System.Collections.Generic;
using juip.Commons;
using juip.Events.Arguments;
using juip.Events.Handlers;
using juip.app.webtemplate.ViewModels;
using juip.Controllers;

namespace juip.app.webtemplate.Controllers 
{ 
    public partial class ApplicationController : ControllerBase
    {
        protected override void OnViewSwitch<T>(ViewSwitchedEventArgs<T> args)  
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

