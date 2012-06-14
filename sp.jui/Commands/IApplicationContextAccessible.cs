using sp.jui.Controllers;

namespace sp.jui.Commands
{
    public interface IApplicationContextAccessible
    {
        IApplicationContext ActionContext { get;  set; }
    }
}