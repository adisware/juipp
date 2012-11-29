using System;
using System.Collections.Generic;
using Org.Juipp.Core.Behaviors;
using WebApplication1._layouts.Views;
using WebApplication1._layouts.Behaviors;
using WebApplication1._layouts.Controllers;
using Org.Juipp.Core.Views;
using Org.Juipp.Core.Controllers;

namespace WebApplication1._layouts.Controllers 
{ 
    public static class ControllerReference
    {
             public const string Controller = "Controller";
             public const string Default1Controller = "Default1Controller";
                 }

    public partial class Container : ContainerBase
    {
	           				protected ControllerBase Controller;
								protected ControllerBase Default1Controller;
				
            
             protected global::WebApplication1._layouts.Views.Default1View Default1View;
              
             protected global::WebApplication1._layouts.Views.DefaultView DefaultView;
             
        protected override void OnInit(EventArgs e) 
        { 
		      
			             base.Controllers.Add(new KeyValuePair<string, ControllerBase>(
                                      ControllerReference.Controller,
                                      new Controller(this) { ID = "Controller" }));
              
			             base.Controllers.Add(new KeyValuePair<string, ControllerBase>(
                                      ControllerReference.Default1Controller,
                                      new Default1Controller(this) { ID = "Default1Controller" }));
             
		    
             base.OnInit(e);

             base.Behaviors = new Dictionary<String, IBehavior>();

              
                 base.Behaviors.Add(new KeyValuePair<string, IBehavior>(
                                        BehaviorReference.DefaultBehavior, 
                                        new DefaultBehavior() { BehaviorContext = this } ));
              
                 base.Behaviors.Add(new KeyValuePair<string, IBehavior>(
                                        BehaviorReference.OpenDefaultBehavior, 
                                        new OpenDefaultBehavior() { BehaviorContext = this } ));
              
                 base.Behaviors.Add(new KeyValuePair<string, IBehavior>(
                                        BehaviorReference.OpenProfileBehavior, 
                                        new OpenProfileBehavior() { BehaviorContext = this } ));
             

            base.Views = new Dictionary<string, ViewBase>();

              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        ViewReference.Default1View,  
                                        this.Default1View ));
              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        ViewReference.DefaultView,  
                                        this.DefaultView ));
                     }
    }
} 

