using System;
using System.Collections.Generic;
using adisware.juipp.Web._layouts.app.Behaviors;
using adisware.juipp.Web._layouts.app.Views;

namespace adisware.juipp.Web._layouts.app.Controllers
{
    public partial class Container {

        protected override void OnBehaviorBinding()
        {
            base.BehaviorBinding = new Dictionary<string, string>();
            base.BehaviorBinding.Add(new KeyValuePair<string, string>(BehaviorReference.MyBehavior,
                                                                      ViewReference.MyView));
        }
    }
}