using System.Collections.Generic;
using sp.jui.Commands;
using sp.jui.Views;

namespace sp.jui.Controllers
{
    public interface IContainCommandViewBinding
    {
        IDictionary<string, IApplicationContextAccessible> Commands { get; set; } 
        IDictionary<string, ApplicationViewBase> Views { get; set; }
        IDictionary<string, string> Binding { get; set; }
    }
}