using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using adisware.juipp.Controllers;
using adisware.juipp.Behaviors;
using adisware.juipp.Events.Handlers;

namespace adisware.Layouts.juipp.Controllers
{
    [
        Controller
        (
            InitialBehaviorFullName = "TargetName@juipp.Behaviors.MyBehavior",
            InitialViewModel = "TargetName@juipp.ViewModels.MyViewModel"
        )
    ]
    public partial class Controller { }
}