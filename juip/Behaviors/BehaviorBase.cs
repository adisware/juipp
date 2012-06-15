using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using juip.Commons;
using juip.Controllers;

namespace juip.Behaviors
{
    [Serializable]
    public abstract class BehaviorBase<T> : IBehavior<T> where T : IViewModel, new()
    {
        public IApplicationContext ActionContext { get; set; }

        public virtual void Execute(Events.Arguments.ActionPerformedEventArgs<T> args)
        {
        }
    }
}
