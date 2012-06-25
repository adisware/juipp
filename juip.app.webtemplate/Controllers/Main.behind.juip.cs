using System;
using System.Collections.Generic;
using juip.Behaviors;
using juip.app.Behaviors;
using juip.Views;
using juip.Controllers;
using TargetName@juip.Views;

namespace TargetName@juip.Controllers 
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

