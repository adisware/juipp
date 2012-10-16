
using System;
using System.Globalization;
using adisware.juipp.Commons;
using adisware.juipp.Events.Arguments;
using adisware.juipp.Web._layouts.app.Behaviors;
using adisware.juipp.Web._layouts.app.ViewModels;

namespace adisware.juipp.Web._layouts.app.Views
{
    public partial class MyView 
    {
        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            this.ButtonHello.Click += this.ButtonOpenStudentProfileClick;
        }


        protected void ButtonOpenStudentProfileClick(object sender, EventArgs e)
        {
            //..translate a [button click event] to a [behavior event]..
            //..that would open StudentProfileView
            this.SendBehaviorEvent(
                new BehaviorEvent<StudentViewModel>()
                {
                    BehaviorReference = BehaviorReference.OpenStudentProfileBehavior,
                    ViewModel = new StudentViewModel()
                                    {
                                        Id = "0001"
                                    }
                });
        }

        public override void OnAfterTransition<T>(BehaviorEvent<T> behaviorEvent)
        {
            // get a behavior context object after a behavior event is executed 
            // ...and the transition event is targeted to this view

            base.OnAfterTransition<T>(behaviorEvent);
            var userViewModel = this.BehaviorContext["UserViewModel"] as UserViewModel;

            if (userViewModel != null)
            {
                var loginName = userViewModel.LoginName;
                var role = userViewModel.Role;
            }
        }
        public void Bind(MyViewModel item)
        {
            // you can also get a behavior context object on bind
            var userViewModel = this.BehaviorContext["UserViewModel"] as UserViewModel;
            if (userViewModel != null)
            {
                var loginName = userViewModel.LoginName;
                var role = userViewModel.Role;
            }
            var date = item.Today;
            this.LabelDate.Text = date.Year.ToString(CultureInfo.InvariantCulture);
        }
    }
}