using juip.Commons;
using juip.Events.Arguments;
using sp.jui.Controllers;

namespace juip.Views
{
    public abstract class SectionViewBase<TD> : ApplicationViewBase, IBindable<TD> where TD : IModel, new()
    {
        protected TD DataItem
        {
            set
            {
                var state = this.ViewState["DataItem"];
                if (state != null) this.ViewState.Remove("DataItem");
                this.ViewState.Add("DataItem", value);
            }
            get
            {
                var state = this.ViewState["DataItem"];
                if (state == null) return default(TD);
                return (TD)state;
            }
        }

        protected override void OnPreRender(System.EventArgs e)
        {
            base.OnPreRender(e);
            this.SetPanelVisibility();
        }

        public abstract void Bind(TD item);
        protected abstract void SetPanelVisibility();

        public IViewSwitchedInvoker<TD> ViewModeChangeInvoker { get; set; }

        public void ViewModeChanged(IViewSwitchedInvoker<TD> sender, IViewSwitchedEventArgs<TD> args)
        {
            var realArgs = ((ViewSwitchedEventArgs<TD>) args);
            this.DataItem = realArgs.DataItem;
            this.Bind(realArgs.DataItem);
        }


        public override void OnViewModeChanged<T>(IViewSwitchedInvoker<T> sender, IViewSwitchedEventArgs<T> args) 
        {
            var realArgs = ((ViewSwitchedEventArgs<TD>) args);
            this.DataItem = realArgs.DataItem;
            this.Bind(realArgs.DataItem);
        }
    }
}