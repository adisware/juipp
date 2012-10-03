using System;
using adisware.juipp.Controllers;
using adisware.juipp.Events.Arguments;
using adisware.juipp.Web._layouts.app.Behaviors;
using adisware.juipp.Web._layouts.app.ViewModels;

namespace adisware.juipp.Web._layouts.app.Controllers
{
    public partial class Controller
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            if (this.Page.IsPostBack) return;

            this.OnBehaviorEventFired( null,
                new BehaviorEvent<MyViewModel>()
                {
                    BehaviorReference = BehaviorReference.MyBehavior,
                    ViewModel = new MyViewModel()
                                    {
                                        Today = DateTime.Now.AddYears(300)
                                    }
                });
        }
    }
}