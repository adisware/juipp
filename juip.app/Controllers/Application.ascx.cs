using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Resources;
using juip.Behaviors;
using juip.Controllers;
using juip.Views;
using juip.app.Behaviors;
using sp.jui.Controllers;

namespace juip.app.Controllers
{
    public partial class Application : ApplicationBase
    {
        protected override void OnBehaviorBinding()
        {
            this.BehaviorBinding = new Dictionary<string, string>()
                               {
                                  { BehaviorNames.OpenHomeBehavior, ViewNames.HomeView },
                                  { BehaviorNames.OpenStudentBrowseBehavior, ViewNames.StudentBrowseView },
                                  { BehaviorNames.OpenStudentAddBehavior, ViewNames.StudentProfileAddView }
                               };
        }
    }
}