using System;
using System.Collections.Generic;
using adisware.juipp.Behaviors;
using adisware.Layouts.application.Admin.Views;
using adisware.Layouts.application.Admin.Behaviors;
using adisware.Layouts.application.Admin.Controllers;
using adisware.juipp.Views;
using adisware.juipp.Controllers;

namespace adisware.Layouts.application.Admin.Controllers 
{ 

    public partial class Container : ContainerBase
    {
           
        protected override void OnInit(EventArgs e) 
        { 
             base.OnInit(e);
             base.Behaviors = new Dictionary<String, IBehavior>();

             

            base.Views = new Dictionary<string, ViewBase>();

                     }
    }
} 

