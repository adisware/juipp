/*  Copyright (c) 2012-2013 Natnael Gebremariam
    http://www.juipp.com
 
    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files (the
    "Software"), to deal in the Software without restriction, including
    without limitation the rights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to
    permit persons to whom the Software is furnished to do so, subject to
    the following conditions:

    The above copyright notice and this permission notice shall be
    included in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using adisware.juipp.Behaviors;
using adisware.juipp.Views;

namespace adisware.juipp.Controllers
{
    public abstract class ContainerBase : 
        System.Web.UI.UserControl, 
        IBehaviorContext
    {
        protected IDictionary<string, ControllerBase> Controllers { get; set; }
        protected IDictionary<string, ViewBase> Views { get; set; }
        protected IDictionary<string, string> ViewControllerBinding { get; set; }
        protected IDictionary<string, string> BehaviorBinding { get; set; }
        protected IDictionary<string, IBehavior> Behaviors { get; set; }

        private readonly IDictionary<string, object> _contextValues = new Dictionary<string, object>();

        protected ContainerBase()
        {
            this.Controllers = new Dictionary<string, ControllerBase>();
        }
        object IBehaviorContext.this[string key]
        {
            get { return _contextValues.ContainsKey(key) == false ? this.RetrieveBindingElement(key) : _contextValues[key]; }
            set
            {
                if (_contextValues.ContainsKey(key)) _contextValues.Remove(key);
                _contextValues.Add(key, value);
                this.PersistBindingElement(key, value);
            }
        }
        
        protected object RetrieveBindingElement(string key)
        {
            var bindingItem = this.ViewState[key];
            return bindingItem;
        }
        protected void PersistBindingElement(string key, object element)
        {
            var bindingItem = this.ViewState[key];
            if (bindingItem != null) this.ViewState.Remove(key);
            this.ViewState.Add(key, element);
        }

        protected override void OnInit(EventArgs e)
        {
          
            base.OnInit(e);
            this.OnBehaviorBinding();
        }
        protected override void CreateChildControls()
        {
            foreach (var controller in Controllers)
            {
                this.Controls.Add(controller.Value);
            }
            base.CreateChildControls();
            base.EnsureChildControls();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.OnViewControllerBinding();
            foreach (var c in Controllers)
            {  
                c.Value.LoadBehaviorViewBinding(
                    this.Views, 
                    this.Behaviors, 
                    this.BehaviorBinding, 
                    this.ViewControllerBinding);
            }
        }

        protected virtual void OnBehaviorBinding()
        {
            this.BehaviorBinding = new Dictionary<string, string>();
        }
        protected virtual void OnViewControllerBinding()
        {
            this.ViewControllerBinding = new Dictionary<string, string>();

            foreach(var key in Views.Keys)
            {
                this.ViewControllerBinding.Add(key, "Controller");
            }
        }
    }
}
