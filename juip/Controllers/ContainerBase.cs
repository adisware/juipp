﻿using System;
using System.Collections.Generic;
using adisware.juipp.Behaviors;
using adisware.juipp.Commons;
using adisware.juipp.Views;

namespace adisware.juipp.Controllers
{
    public abstract class ContainerBase : System.Web.UI.UserControl, IContainBehaviorViewBinding
    {
        protected ControllerBase Controller;

        public IDictionary<string, ViewBase> Views { get; set; }
        public IDictionary<string, string> BehaviorBinding { get; set; }
        public IDictionary<string, IBehavior> Behaviors { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.OnBehaviorBinding();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Controller != null) this.Controller.LoadBehaviorViewBinding(this.Views, this.BehaviorBinding, this.Behaviors);
        }
        protected virtual void OnBehaviorBinding()
        {
            this.BehaviorBinding = new Dictionary<string, string>();
        }
    }
}
