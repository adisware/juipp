using System.Collections.Generic;
using juip.app.Views;
using juip.app.webtemplate.Behaviors;

namespace juip.app.webtemplate.Controllers
{
    public partial class Main
    {
        protected override void OnBehaviorBinding()
        {
            base.BehaviorBinding = new Dictionary<string, string>
                                       {
                                       };
        }
    }
}