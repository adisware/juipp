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

            // create an instance of a viewModel
            var viewModel = new MyViewModel() { Today = DateTime.Now.AddYears(300) };

            // define a behaviorEvent containing a behavior reference and the viewModel
            var behaviorEvent = new BehaviorEvent<MyViewModel>()
                        {
                            BehaviorReference = BehaviorReference.MyBehavior,
                            ViewModel = viewModel
                        };

            //fire the behavior event
            this.FireBehaviorEvent(behaviorEvent);
        }
    }
}