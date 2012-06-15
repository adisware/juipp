using juip.Controllers;
using sp.jui.Controllers;

namespace juip.Behaviors
{
    public interface IApplicationContextAccessible
    {
        IApplicationContext ActionContext { get;  set; }
    }
}