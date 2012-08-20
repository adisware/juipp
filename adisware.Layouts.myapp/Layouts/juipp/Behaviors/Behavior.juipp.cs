using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.Behaviors;
using adisware.juipp.Controllers;
using adisware.Layouts.juipp.ViewModels;

namespace adisware.Layouts.juipp.Behaviors 
{
    public static class BehaviorReference 
    {
             public static string MyBehavior = "adisware.Layouts.juipp.Behaviors.MyBehavior";
                 }
	 public partial class MyBehavior : BehaviorBase{}
    


		        
	public partial class BehaviorBase 
	{
		public IBehaviorContext BehaviorContext { get; set; }
}

	   public partial class BehaviorBase : IExecutableBehavior<MyViewModel>
   {
		public virtual void Execute(BehaviorEvent<MyViewModel> args) {}
   }
} 

