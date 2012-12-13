using System;
using System.Collections.Generic;
using $rootnamespace$.Behaviors;
using $rootnamespace$.Views;

namespace $rootnamespace$.Controllers
{
    public partial class Container 
    {
        protected override void OnBehaviorBinding()
        {
            base.BehaviorBinding = new Dictionary<string, string>()
                                       {
                                           {BehaviorReference.OpenDefaultHomeBehavior, ViewReference.DefaultView}
                                       };
        }
    }
}