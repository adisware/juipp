using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using adisware.juipp.Controllers;
using adisware.juipp.Behaviors;
using adisware.juipp.Events.Handlers;

namespace $safeprojectname$.Controllers
{
    [
        Controller
        (
            InitialBehaviorFullName = "$safeprojectname$.Behaviors.MyBehavior",
            InitialViewModel = "$safeprojectname$.ViewModels.MyViewModel"
        )
    ]
    public partial class Controller { }
}