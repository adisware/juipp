using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using sp.jui.Commands;
using sp.jui.Views;

namespace sp.jui.Controllers
{
    public interface ICommandNames
    {
        IList<String> Names { get; set; } 
    }
    public abstract class CommandViewBindingBase : UserControl, IContainCommandViewBinding, ICommandNames
    {
        public abstract string CommandAssemblyName { get; }
      
        public IDictionary<string, IApplicationContextAccessible> Commands { get; set; }

        public abstract IDictionary<string, ApplicationViewBase> Views { get; set; }

        public abstract IDictionary<string, string> Binding { get; set; }

        public IList<string> Names { get; set; }

        protected CommandViewBindingBase(IApplicationContext context, IApplicationContextAccessible contextAccessible)
        {
            var commandNames = new List<String>();
            
            var assembly = contextAccessible.GetType().Assembly;

            var types = assembly.GetTypes();

            foreach(var type in types)
            {
                var attributes = type.GetCustomAttributes(false);
                foreach (var commandAttribute in attributes.OfType<CommandAttribute>())
                {
                    commandNames.Add(commandAttribute.Name);

                    var commandType = commandAttribute.Model == null ? type : type.MakeGenericType(commandAttribute.Model);
                    var ctor = commandType.GetConstructor(new[] { typeof(IApplicationContext) });
                    if (ctor == null) continue;
                    var obj = ctor.Invoke(new object[] { context });
                    Commands.Add(commandAttribute.Name, obj as IApplicationContextAccessible);
                }
            }
        }
    }
}
