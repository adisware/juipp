using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Resources;
using juip.Behaviors;
using juip.Views;
using juip.app.Behaviors;

namespace juip.app.Controllers
{
    public partial class Application
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            base.Controller = this.Controller;

            this.Behaviors = new Dictionary<string, IApplicationContextAccessible>()
                                 {
                                     { BehaviorNames.OpenHomeBehavior, new OpenHomeBehavior() {ActionContext = this.Controller} } ,
                                     { BehaviorNames.OpenStudentBrowseBehavior, new OpenStudentBrowseBehavior() {ActionContext = this.Controller} } ,
                                 };

            this.Views = new Dictionary<string, ApplicationViewBase>()
                             {
                                 {ViewNames.HomeView, this.HomeView},
                                 {ViewNames.StudentBrowseView, this.StudentBrowseView},
                                 {ViewNames.StudentProfileAddView, this.StudentProfileAddView},
                                 {ViewNames.StudentProfileEditView, this.StudentProfileEditView},
                                 {ViewNames.StudentProfileView, this.StudentProfileView}
                             };
           
        }
    }
}