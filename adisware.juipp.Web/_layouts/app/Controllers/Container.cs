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
          
            base.BehaviorBinding.Add(BehaviorReference.MyBehavior, ViewReference.MyView);
        }
    }
}