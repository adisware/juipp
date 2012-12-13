using Org.Juipp.Core.Events.Arguments;
using Org.Juipp.Core.Events.Handlers;
using Org.Juipp.Core.Behaviors;
using Org.Juipp.Core.Controllers;
using WebApplication1._layouts.ViewModels;

namespace WebApplication1._layouts.Behaviors 
{
    public static partial class BehaviorReference 
    {
             public const string DefaultBehavior = "DefaultBehavior";
             public const string OpenDefaultBehavior = "OpenDefaultBehavior";
             public const string OpenProfileBehavior = "OpenProfileBehavior";
             
    }
	     public partial class DefaultBehavior : BehaviorBase{} 
        public partial class OpenDefaultBehavior : BehaviorBase{} 
        public partial class OpenProfileBehavior : BehaviorBase{} 
    

  
    public partial class BehaviorBase 
	{
		public IBehaviorContext BehaviorContext { get; set; }
    }


	   public partial class BehaviorBase : IExecutableBehavior<Default1ViewModel>
   {
		public virtual void Execute(BehaviorEvent<Default1ViewModel> args) {}
   }
   public partial class BehaviorBase : IExecutableBehavior<DefaultViewModel>
   {
		public virtual void Execute(BehaviorEvent<DefaultViewModel> args) {}
   }
} 

