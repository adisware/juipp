using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using juip.Events.Arguments;
using juip.Views;
using juip.app.Behaviors;
using juip.app.ViewModels;

namespace juip.app.Views
{
    public partial class HomeView : ApplicationView
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.ButtonStudentAdd.Click += this.ButtonStudentAddClick;
            this.ButtonStudentBrowse.Click += this.ButtonStudentBrowseClick;
        }

        protected void ButtonStudentBrowseClick(object sender, EventArgs e)
        {
            this.OnActionPerformed(new ActionPerformedEventArgs<StudentViewModel>(e)
            {
                BehaviorName = Behavior.OpenStudentBrowseBehavior
            });
        }

        protected void ButtonStudentAddClick(object sender, EventArgs e)
        {
            this.OnActionPerformed(new ActionPerformedEventArgs<StudentViewModel>(e)
            {
                BehaviorName = Behavior.OpenStudentAddBehavior
            });
        }
    }
}