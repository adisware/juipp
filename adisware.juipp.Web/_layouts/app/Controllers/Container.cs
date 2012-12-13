using System;
using System.Collections.Generic;
using adisware.juipp.Web._layouts.app.Behaviors;
using adisware.juipp.Web._layouts.app.Views;

namespace adisware.juipp.Web._layouts.app.Controllers
{
public partial class Container {

    protected override void OnBehaviorBinding()
    {
        base.OnBehaviorBinding();

        // runtime conditional application context
        var isAdminRole = false;

        //dynamic behavior binding
        if(isAdminRole) 
            base.BehaviorBinding.Add(
                BehaviorReference.OpenHomeBehavior, 
                ViewReference.HomeAdminView);
        else 
            base.BehaviorBinding.Add(
                BehaviorReference.OpenHomeBehavior, 
                ViewReference.HomeView);

        base.BehaviorBinding.Add(
            BehaviorReference.OpenStudentProfileBehavior, 
            ViewReference.StudentProfileView);

    }
}
}