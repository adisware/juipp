using System;
using System.Collections.Generic;
using adisware.juipp.Behaviors;
using adisware.Layouts.juipp.Views;
using adisware.Layouts.juipp.Behaviors;
using adisware.Layouts.juipp.Controllers;
using adisware.juipp.Views;
using adisware.juipp.Controllers;

namespace adisware.Layouts.juipp.Controllers 
{ 

    public partial class Container : ContainerBase
    {
            
             protected global::adisware.Layouts.juipp.Views.MyView MyView;
             
        protected override void OnInit(EventArgs e) 
        { 
             base.OnInit(e);
             base.Behaviors = new Dictionary<String, IBehavior>();

              
                 base.Behaviors.Add(new KeyValuePair<string, IBehavior>(
                                        BehaviorReference.MyBehavior, 
                                        new MyBehavior() { BehaviorContext = base.Controller } ));
             

            base.Views = new Dictionary<string, ViewBase>();

              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        ViewReference.MyView,  
                                        this.MyView ));
                           //this.Controller.LoadBehaviorViewBinding(this.Views, this.BehaviorBinding, this.Behaviors);
        }
    }
} 

