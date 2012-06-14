using System;

namespace sp.jui.Commands
{
    [AttributeUsage(
        AttributeTargets.Class, 
        Inherited = false,
        AllowMultiple = true)]
    public class CommandAttribute : Attribute
    {
        public string Name { get; set; }
        public Type Model { get; set; }
    }
}
