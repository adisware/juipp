using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using juip.Behaviors;
using juip.Views;
using sp.jui.Controllers;

namespace juip.Controllers
{
    public abstract class ApplicationBase : System.Web.UI.UserControl, IContainBehaviorViewBinding
    {
        protected ControllerBase Controller;

        public IDictionary<string, ApplicationViewBase> Views { get; set; }
        public IDictionary<string, string> BehaviorBinding { get; set; }
        public IDictionary<string, IApplicationContextAccessible> Behaviors { get; set; }

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
        protected abstract void OnBehaviorBinding();
    }
}
