using System;

namespace juip.Behaviors
{
    [AttributeUsage(
        AttributeTargets.Class, 
        Inherited = false,
        AllowMultiple = true)]
    public class BehaviorAttribute : Attribute
    {
        public string Name { get; set; }
        public Type Model { get; set; }
    }
}
