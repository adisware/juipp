using System;
using System.Security.Principal;
using adisware.juipp.Controllers;
using adisware.juipp.Events.Arguments;
using adisware.juipp.Views;
using adisware.juipp.Web._layouts.app.Behaviors;
using adisware.juipp.Web._layouts.app.ViewModels;

namespace adisware.juipp.Web._layouts.app.Controllers
{
public partial class Controller
{
    protected override void InitBehaviorContext()
    {
        base.InitBehaviorContext();

        var identity = WindowsIdentity.GetCurrent();
        (this as IBehaviorContext)["UserViewModel"] =
            new UserViewModel()
                {
                    LoginName = identity != null ? identity.Name : null,
                    Role = "regular-user"
                };
    }

    protected override void OnBeforeBehaviorEvent<T>(IBehaviorEventSender<T> sender, BehaviorEvent<T> behaviorEvent)
    {
        base.OnBeforeBehaviorEvent<T>(sender, behaviorEvent);

        if(behaviorEvent.BehaviorReference == BehaviorReference.MyBehavior)
        {
            (this as IBehaviorContext)["UserViewModel"] =
            new UserViewModel()
            {
                LoginName = @"domain\somelogin",
                Role = "admin-role"
            };
        }
    }
}
}