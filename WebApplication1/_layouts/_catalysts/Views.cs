using Org.Juipp.Core.Events.Arguments;
using Org.Juipp.Core.Events.Handlers;
using Org.Juipp.Core.Views;
using WebApplication1._layouts.ViewModels;

namespace WebApplication1._layouts.Views 
{
   
    public partial class View : ViewBase 
	{
		public Default1ViewModel Default1ViewModel
        {
            get { return base.RetrieveBindingElement<Default1ViewModel>(); }
            set { base.PersistBindingElement(value); }
        }
		public DefaultViewModel DefaultViewModel
        {
            get { return base.RetrieveBindingElement<DefaultViewModel>(); }
            set { base.PersistBindingElement(value); }
        }
			
	}
    
    public static class ViewReference
    {
             public static string Default1View = "Default1View";
             public static string DefaultView = "DefaultView";
                 }

     
        public partial class View : IBehaviorEventSender<Default1ViewModel> 
        {
            private BehaviorEventHandler<Default1ViewModel> _default1ViewModelBehaviorEventFired;
            event BehaviorEventHandler<Default1ViewModel> IBehaviorEventSender<Default1ViewModel>.BehaviorEventFired
            {
                add
                {
                    _default1ViewModelBehaviorEventFired += value;
                    base.FireBehaviorEventDelegates.Add(args => base.FireBehaviorEvent(_default1ViewModelBehaviorEventFired, args as BehaviorEvent<Default1ViewModel>));
                }
                remove { if (_default1ViewModelBehaviorEventFired != null) _default1ViewModelBehaviorEventFired -= value; }
            }
        }
     
        public partial class View : IBehaviorEventSender<DefaultViewModel> 
        {
            private BehaviorEventHandler<DefaultViewModel> _defaultViewModelBehaviorEventFired;
            event BehaviorEventHandler<DefaultViewModel> IBehaviorEventSender<DefaultViewModel>.BehaviorEventFired
            {
                add
                {
                    _defaultViewModelBehaviorEventFired += value;
                    base.FireBehaviorEventDelegates.Add(args => base.FireBehaviorEvent(_defaultViewModelBehaviorEventFired, args as BehaviorEvent<DefaultViewModel>));
                }
                remove { if (_defaultViewModelBehaviorEventFired != null) _defaultViewModelBehaviorEventFired -= value; }
            }
        }
    } 

