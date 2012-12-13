using System;
using System.Security.Principal;
using adisware.juipp.Controllers;
using adisware.juipp.Events.Arguments;
using adisware.juipp.Views;
using ItemTemplate1.Behaviors;
using ItemTemplate1.ViewModels;

namespace ItemTemplate1.Controllers
{
    public partial class Controller
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.Page.IsPostBack) return;

            this.FireBehaviorEvent<DefaultViewModel>(
                new BehaviorEvent<DefaultViewModel>()
                {
                    BehaviorReference = BehaviorReference.OpenDefaultBehavior
                });
        }
    }
}