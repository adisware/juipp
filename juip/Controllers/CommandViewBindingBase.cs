using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using adisware.juipp.Behaviors;
using adisware.juipp.Views;

namespace adisware.juipp.Controllers
{
    public abstract class BehaviorViewBindingBase : UserControl, IContainBehaviorViewBinding, IBehaviorNames
    {
        public abstract string BehaviorAssemblyName { get; }
      
        public IDictionary<string, IBehavior> Behaviors { get; set; }

        public abstract IDictionary<string, ViewBase> Views { get; set; }

        public abstract IDictionary<string, string> BehaviorBinding { get; set; }

        public IList<string> Names { get; set; }

        protected BehaviorViewBindingBase(IBehaviorContext context, IBehavior contextAccessible)
        {
            var behaviorNames = new List<String>();
            
            var assembly = contextAccessible.GetType().Assembly;

            var types = assembly.GetTypes();

            foreach(var type in types)
            {
                var attributes = type.GetCustomAttributes(false);
                foreach (var behaviorAttribute in attributes.OfType<BehaviorAttribute>())
                {
                    behaviorNames.Add(behaviorAttribute.Name);

                    var behaviorType = behaviorAttribute.ViewModelReference == null ? type : type.MakeGenericType(typeof(object));
                    var ctor = behaviorType.GetConstructor(new[] { typeof(IBehaviorContext) });
                    if (ctor == null) continue;
                    var obj = ctor.Invoke(new object[] { context });
                    Behaviors.Add(behaviorAttribute.Name, obj as IBehavior);
                }
            }
        }
    }
}
