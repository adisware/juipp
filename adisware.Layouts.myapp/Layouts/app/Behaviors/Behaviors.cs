﻿using adisware.juipp.Events.Arguments;
using adisware.juipp.Events.Handlers;
using adisware.juipp.Behaviors;
using adisware.juipp.Controllers;
using adisware.Layouts.app.ViewModels;

namespace adisware.Layouts.app.Behaviors 
{
    public static partial class BehaviorReference 
    {
             public const string MyBehavior = "MyBehavior";
             
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

