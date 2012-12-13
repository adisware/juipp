using System;
using System.Collections.Generic;
using ItemTemplate1.Behaviors;
using ItemTemplate1.Views;

namespace ItemTemplate1.Controllers
{
    public partial class Container
    {
        protected override void OnBehaviorBinding()
        {
            base.BehaviorBinding = new Dictionary<string, string>()
                                       {
                                           {BehaviorReference.OpenDefaultBehavior, ViewReference.DefaultView}
                                       };
        }
    }
}