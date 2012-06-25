using System;
using System.Collections.Generic;
using juip.Behaviors;
using juip.app.Behaviors;
using juip.Views;
using juip.Controllers;
using juip.app.Views;

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
                                        Behavior.OpenHomeBehavior, 
                                        new OpenHomeBehavior() { ActionContext = base.Controller } ));
              
                 base.Behaviors.Add(new KeyValuePair<string, IApplicationContextAccessible>(
                                        Behavior.OpenStudentAddBehavior, 
                                        new OpenStudentAddBehavior() { ActionContext = base.Controller } ));
              
                 base.Behaviors.Add(new KeyValuePair<string, IApplicationContextAccessible>(
                                        Behavior.OpenStudentBrowseBehavior, 
                                        new OpenStudentBrowseBehavior() { ActionContext = base.Controller } ));
             

            base.Views = new Dictionary<string, ApplicationViewBase>();

              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        View.HomeView,  
                                        this.HomeView ));
              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        View.StudentBrowseView,  
                                        this.StudentBrowseView ));
              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        View.StudentProfileAddView,  
                                        this.StudentProfileAddView ));
              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        View.StudentProfileEditView,  
                                        this.StudentProfileEditView ));
              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        View.StudentProfileView,  
                                        this.StudentProfileView ));
              
                 base.Views.Add(new KeyValuePair<string, ApplicationViewBase>(
                                        View.WorkView,  
                                        this.WorkView ));
                           this.Controller.LoadBehaviorViewBinding(this.Views, this.BehaviorBinding, this.Behaviors);
        }
    }
} 

