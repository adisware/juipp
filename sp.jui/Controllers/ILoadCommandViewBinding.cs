using System.Collections.Generic;
using sp.jui.Commands;
using sp.jui.Views;

namespace sp.jui.Controllers
{
    public interface ILoadCommandViewBinding
    {
        void LoadCommandViewBinding(
            IDictionary<string, ApplicationViewBase> views,
            IDictionary<string, string> binding,
            IDictionary<string, IApplicationContextAccessible> commands);
    }
}