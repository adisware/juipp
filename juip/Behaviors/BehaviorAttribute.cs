using System;

namespace sp.jui.Behaviors
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
