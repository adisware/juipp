using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using juip.app.Behaviors;
using juip.app.ViewModels;
using juip.app.Views;

namespace juip.app.Controllers
{
    public partial class Main
    {
        protected override void OnBehaviorBinding()
        {
            base.BehaviorBinding = new Dictionary<string, string>
                                       {
                                           {Behavior.OpenHomeBehavior, View.HomeView},
                                           {Behavior.OpenStudentBrowseBehavior, View.StudentBrowseView}
                                       };
        }
    }
}