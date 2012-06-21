using System;
using System.Collections.Generic;
using Resources;
using juip.Behaviors;
using juip.app.Behaviors;
using juip.Views;
using juip.Controllers;


namespace juip.app.Controllers 
{ 

    public partial class Main : ApplicationBase
    {
            
             protected global::juip.app.Views.HomeView HomeView;
              
             protected global::juip.app.Views.StudentBrowseView StudentBrowseView;
              
             protected global::juip.app.Views.StudentProfileAddView StudentProfileAddView;
              
             protected global::juip.app.Views.StudentProfileEditView StudentProfileEditView;
              
             protected global::juip.app.Views.StudentProfileView StudentProfileView;
              
             protected global::juip.app.Views.WorkView WorkView;
             
        protected override void OnInit(EventArgs e) 
        { 
             base.OnInit(e);
             base.Behaviors = new Dictionary<String, IApplicationContextAccessible>();

              
                 base.Behaviors.Add(new KeyValuePair<string, IApplicationContextAccessible>(
                                        BehaviorNames.OpenHomeBehavior, 
                                        new OpenHomeBehavior() { ActionContext = base.Controller } ));
              
                 base.Behaviors.Add(new KeyValuePair<string, IApplicationContextAccessible>(
                                        BehaviorNames.OpenStudentBrowseBehavior, 
                                        new OpenStudentBrowseBehavior() { ActionContext = base.Controller } ));
             

            base.Views = new Dictionary<string, ApplicationViewBase>();

              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        ViewNames.HomeView,  
                                        this.HomeView ));
              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        ViewNames.StudentBrowseView,  
                                        this.StudentBrowseView ));
              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        ViewNames.StudentProfileAddView,  
                                        this.StudentProfileAddView ));
              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        ViewNames.StudentProfileEditView,  
                                        this.StudentProfileEditView ));
              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        ViewNames.StudentProfileView,  
                                        this.StudentProfileView ));
              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        ViewNames.WorkView,  
                                        this.WorkView ));
                           this.Controller.LoadBehaviorViewBinding(this.Views, this.BehaviorBinding, this.Behaviors);
        }
    }
} 

