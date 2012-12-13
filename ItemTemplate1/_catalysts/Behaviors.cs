using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.Behaviors;
using adisware.juipp.Controllers;
using ItemTemplate1.ViewModels;

namespace ItemTemplate1.Behaviors 
{
    public static partial class BehaviorReference 
    {
             public const string OpenDefaultBehavior = "OpenDefaultBehavior";
             
    }
	     public partial class OpenDefaultBehavior : BehaviorBase{} 
    

  
    public partial class BehaviorBase 
	{
		public IBehaviorContext BehaviorContext { get; set; }
    }


	   public partial class BehaviorBase : IExecutableBehavior<DefaultViewModel>
   {
		public virtual void Execute(BehaviorEvent<DefaultViewModel> args) {}
   }
} 

