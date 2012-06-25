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

