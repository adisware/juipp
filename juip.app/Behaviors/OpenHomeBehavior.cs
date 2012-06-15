using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using juip.Behaviors;
using juip.app.ViewModels;

namespace juip.app.Behaviors
{
    [Behavior(Name = "juip.app.Behaviors.OpenHomeBehavior")]
    public class OpenHomeBehavior : BehaviorBase<StudentViewModel> {}
}