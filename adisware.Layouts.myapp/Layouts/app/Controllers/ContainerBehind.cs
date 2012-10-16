using System;
using System.Collections.Generic;
using adisware.juipp.Behaviors;
using adisware.Layouts.app.Views;
using adisware.Layouts.app.Behaviors;
using adisware.Layouts.app.Controllers;
using adisware.juipp.Views;
using adisware.juipp.Controllers;

namespace adisware.Layouts.app.Controllers 
{ 

    public partial class Container : ContainerBase
    {
           
        protected override void OnInit(EventArgs e) 
        { 
             base.OnInit(e);
             base.Behaviors = new Dictionary<String, IBehavior>();

              
                 base.Behaviors.Add(new KeyValuePair<string, IBehavior>(
                                        BehaviorReference.MyBehavior, 
                                        new MyBehavior() { BehaviorContext = base.Controller } ));
             

            base.Views = new Dictionary<string, ViewBase>();

                     }
    }
} 

