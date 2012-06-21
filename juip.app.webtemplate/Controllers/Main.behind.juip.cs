using System;
using System.Collections.Generic;
using juip.Behaviors;
using juip.app.webtemplate.Behaviors;
using juip.Views;
using juip.Controllers;
using juip.app.Views;

namespace juip.app.webtemplate.Controllers 
{ 

    public partial class Main : ApplicationBase
    {
           
        protected override void OnInit(EventArgs e) 
        { 
             base.OnInit(e);
             base.Behaviors = new Dictionary<String, IApplicationContextAccessible>();

             

            base.Views = new Dictionary<string, ApplicationViewBase>();

                           this.Controller.LoadBehaviorViewBinding(this.Views, this.BehaviorBinding, this.Behaviors);
        }
    }
} 

