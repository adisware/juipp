using System;
using System.Collections.Generic;
using adisware.juipp.Behaviors;
using ItemTemplate1.Views;
using ItemTemplate1.Behaviors;
using ItemTemplate1.Controllers;
using adisware.juipp.Views;
using adisware.juipp.Controllers;

namespace ItemTemplate1.Controllers 
{ 
    public static class ControllerReference
    {
             public const string Controller = "Controller";
                 }

    public partial class Container : ContainerBase
    {
	           				protected ControllerBase Controller;
				
            
             protected global::ItemTemplate1.Views.DefaultView DefaultView;
             
        protected override void OnInit(EventArgs e) 
        { 
		      
			             base.Controllers.Add(new KeyValuePair<string, ControllerBase>(
                                      ControllerReference.Controller,
                                      new Controller(this) { ID = "Controller" }));
             
		    
             base.OnInit(e);

             base.Behaviors = new Dictionary<String, IBehavior>();

              
                 base.Behaviors.Add(new KeyValuePair<string, IBehavior>(
                                        BehaviorReference.OpenDefaultBehavior, 
                                        new OpenDefaultBehavior() { BehaviorContext = this } ));
             

            base.Views = new Dictionary<string, ViewBase>();

              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        ViewReference.DefaultView,  
                                        this.DefaultView ));
                     }
    }
} 

