using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.Behaviors;
using adisware.juipp.Controllers;
using adisware.juipp.Web._layouts.app.ViewModels;

namespace adisware.juipp.Web._layouts.app.Behaviors 
{
    public static partial class BehaviorReference 
    {
             public const string MyBehavior = "MyBehavior";
             public const string OpenHomeBehavior = "OpenHomeBehavior";
             public const string OpenStudentProfileBehavior = "OpenStudentProfileBehavior";
             
    }
	     public partial class MyBehavior : BehaviorBase{} 
        public partial class OpenHomeBehavior : BehaviorBase{} 
        public partial class OpenStudentProfileBehavior : BehaviorBase{} 
    


		        
    public partial class BehaviorBase 
	{
		public IBehaviorContext BehaviorContext { get; set; }
    }


	   public partial class BehaviorBase : IExecutableBehavior<MyViewModel>
   {
		public virtual void Execute(BehaviorEvent<MyViewModel> args) {}
   }
   public partial class BehaviorBase : IExecutableBehavior<StudentViewModel>
   {
		public virtual void Execute(BehaviorEvent<StudentViewModel> args) {}
   }
   public partial class BehaviorBase : IExecutableBehavior<UserViewModel>
   {
		public virtual void Execute(BehaviorEvent<UserViewModel> args) {}
   }
} 

