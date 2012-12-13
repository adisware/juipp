using System;
using System.Collections.Generic;
using WebApplication1._layouts.Behaviors;
using WebApplication1._layouts.Views;

namespace WebApplication1._layouts.Controllers
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