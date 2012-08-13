using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using juipp.Behaviors;
using juipp.Commons;

namespace juipp.Controllers
{
    public class ControllerAttribute : Attribute
    {
        public string InitialBehaviorFullName { get; set; }
        public string InitialViewModel { get; set; }
    }
}
