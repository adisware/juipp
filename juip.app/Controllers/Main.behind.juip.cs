using System;
using System.Collections.Generic;
using juip.Behaviors;
using TargetName@juip.Behaviors;
using juip.Views;
using juip.Controllers;
using TargetName@juip.Views;

namespace TargetName@juip.Controllers 
{ 

    public partial class Main : ApplicationBase
    {
            
             protected global::TargetName@juip.Views.HomeView HomeView;
              
             protected global::TargetName@juip.Views.StudentBrowseView StudentBrowseView;
              
             protected global::TargetName@juip.Views.StudentProfileAddView StudentProfileAddView;
              
             protected global::TargetName@juip.Views.StudentProfileEditView StudentProfileEditView;
              
             protected global::TargetName@juip.Views.StudentProfileView StudentProfileView;
              
             protected global::TargetName@juip.Views.WorkView WorkView;
             
        protected override void OnInit(EventArgs e) 
        { 
             base.OnInit(e);
             base.Behaviors = new Dictionary<String, IApplicationContextAccessible>();

              
                 base.Behaviors.Add(new KeyValuePair<string, IApplicationContextAccessible>(
                                        Behavior.Behavior, 
                                        new Behavior() { ActionContext = base.Controller } ));
              
                 base.Behaviors.Add(new KeyValuePair<string, IApplicationContextAccessible>(
                                        Behavior.OpenHomeBehavior, 
                                        new OpenHomeBehavior() { ActionContext = base.Controller } ));
              
                 base.Behaviors.Add(new KeyValuePair<string, IApplicationContextAccessible>(
                                        Behavior.OpenStudentAddBehavior, 
                                        new OpenStudentAddBehavior() { ActionContext = base.Controller } ));
              
                 base.Behaviors.Add(new KeyValuePair<string, IApplicationContextAccessible>(
                                        Behavior.OpenStudentBrowseBehavior, 
                                        new OpenStudentBrowseBehavior() { ActionContext = base.Controller } ));
             

            base.Views = new Dictionary<string, ViewBase>();

              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        View.HomeView,  
                                        this.HomeView ));
              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        View.StudentBrowseView,  
                                        this.StudentBrowseView ));
              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        View.StudentProfileAddView,  
                                        this.StudentProfileAddView ));
              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        View.StudentProfileEditView,  
                                        this.StudentProfileEditView ));
              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        View.StudentProfileView,  
                                        this.StudentProfileView ));
              
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        View.WorkView,  
                                        this.WorkView ));
                           this.Controller.LoadBehaviorViewBinding(this.Views, this.BehaviorBinding, this.Behaviors);
        }
    }
} 

