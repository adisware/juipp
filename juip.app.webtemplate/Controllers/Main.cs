using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using juip.app.webtemplate.Behaviors;
using juip.app.webtemplate.ViewModels;
using juip.app.webtemplate.Views;

namespace juip.app.webtemplate.Controllers
{
    public partial class Main
    {
        protected override void OnBehaviorBinding()
        {
            base.BehaviorBinding = new Dictionary<string, string>
                                       {
                                       };
        }
    }
}