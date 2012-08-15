using System;

namespace adisware.juipp.Controllers
{
    public class ControllerAttribute : Attribute
    {
        public string InitialBehaviorFullName { get; set; }
        public string InitialViewModel { get; set; }
    }
}
