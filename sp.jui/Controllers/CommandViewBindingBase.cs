﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using sp.jui.Behaviors;
using sp.jui.Behaviors;
using sp.jui.Views;

namespace sp.jui.Controllers
{
    public abstract class BehaviorViewBindingBase : UserControl, IContainBehaviorViewBinding, IBehaviorNames
    {
        public abstract string BehaviorAssemblyName { get; }
      
        public IDictionary<string, IApplicationContextAccessible> Behaviors { get; set; }

        public abstract IDictionary<string, ApplicationViewBase> Views { get; set; }

        public abstract IDictionary<string, string> Binding { get; set; }

        public IList<string> Names { get; set; }

        protected BehaviorViewBindingBase(IApplicationContext context, IApplicationContextAccessible contextAccessible)
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

                    var behaviorType = behaviorAttribute.Model == null ? type : type.MakeGenericType(behaviorAttribute.Model);
                    var ctor = behaviorType.GetConstructor(new[] { typeof(IApplicationContext) });
                    if (ctor == null) continue;
                    var obj = ctor.Invoke(new object[] { context });
                    Behaviors.Add(behaviorAttribute.Name, obj as IApplicationContextAccessible);
                }
            }
        }
    }
}
