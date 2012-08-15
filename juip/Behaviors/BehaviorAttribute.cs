using System;

namespace adisware.juipp.Behaviors
{
    [AttributeUsage(
        AttributeTargets.Class, 
        Inherited = false,
        AllowMultiple = true)]
    public class BehaviorAttribute : Attribute
    {
        public string Name { get; set; }
        public string ViewModelReference { get; set; }
    }
}
