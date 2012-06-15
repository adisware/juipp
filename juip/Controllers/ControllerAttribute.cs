using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using juip.Behaviors;
using juip.Commons;

namespace juip.Controllers
{
    public class ControllerAttribute : Attribute
    {
        public string InitialBehaviorName { get; set; }
    }
}
