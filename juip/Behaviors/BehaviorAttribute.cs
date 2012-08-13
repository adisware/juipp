using System;
using juipp.Commons;

namespace juipp.Behaviors
{
    [AttributeUsage(
        AttributeTargets.Class, 
        Inherited = false,
        AllowMultiple = true)]
    public class BehaviorAttribute : Attribute
    {
        public string Name { get; set; }
        public string ViewModelName { get; set; }
    }
}
