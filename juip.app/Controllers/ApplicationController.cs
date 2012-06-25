using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using juip.Behaviors;
using juip.Controllers;
using juip.Events.Handlers;

namespace juip.app.Controllers
{
    [Controller(InitialBehaviorFullName = "juip.app.Behaviors.OpenHomeBehavior")]
    public partial class ApplicationController
    {
        public override void InitApplicationContext()
        {
            var context = (IApplicationContext) this;
            // example of how to add application context that can be accessed by "behaviors" through the IApplicationContext interface
            // context["context_value"] = new object();
        }
    }
}