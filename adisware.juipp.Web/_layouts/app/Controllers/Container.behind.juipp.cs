using System;
using System.Collections.Generic;
using adisware.juipp.Behaviors;
using adisware.juipp.Web._layouts.app.Views;
using adisware.juipp.Web._layouts.app.Behaviors;
using adisware.juipp.Web._layouts.app.Controllers;
using adisware.juipp.Views;
using adisware.juipp.Controllers;

namespace adisware.juipp.Web._layouts.app.Controllers 
{ 

    public partial class Container : ContainerBase
    {
            
             protected global::adisware.juipp.Web._layouts.app.Views.MyView MyView;
              
             protected global::adisware.juipp.Web._layouts.app.Views.StudentProfileView StudentProfileView;
             
        protected override void OnInit(EventArgs e) 
        { 
             base.OnInit(e);
             base.Behaviors = new Dictionary<String, IBehavior>();

              
                 base.Behaviors.Add(new KeyValuePair<string, IBehavior>(
                                        BehaviorReference.MyBehavior, 
                                        new MyBehavior() { BehaviorContext = base.Controller } ));
              
                 base.Behaviors.Add(new KeyValuePair<string, IBehavior>(
                                        BehaviorReference.OpenStudentProfileBehavior, 
                                        new OpenStudentProfileBehavior() { BehaviorContext = base.Controller } ));
             

            base.Views = new Dictionary<string, ViewBase>();

              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        ViewReference.MyView,  
                                        this.MyView ));
              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        ViewReference.StudentProfileView,  
                                        this.StudentProfileView ));
                           //this.Controller.LoadBehaviorViewBinding(this.Views, this.BehaviorBinding, this.Behaviors);
        }
    }
} 

