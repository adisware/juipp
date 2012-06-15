using sp.jui.Controllers;

namespace sp.jui.Behaviors
{
    public interface IApplicationContextAccessible
    {
        IApplicationContext ActionContext { get;  set; }
    }
}