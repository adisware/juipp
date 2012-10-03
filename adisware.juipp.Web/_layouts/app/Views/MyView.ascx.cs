
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
            this.ButtonHello.Click += this.ButtonHelloClick;
        }


        protected void ButtonHelloClick(object sender, System.EventArgs e)
        {
            this.SendBehaviorEvent(new BehaviorEvent<MyViewModel>()
                                       {
                                           BehaviorReference = BehaviorReference.MyBehavior,
                                           ViewModel = new MyViewModel()
                                                           {
                                                               Today = DateTime.Now.AddDays(-300)
                                                           }
                                       });
        }

        public void Bind(MyViewModel item)
        {
            var date = item.Today;
            this.LabelDate.Text = date.Year.ToString(CultureInfo.InvariantCulture);
        }

    }
}