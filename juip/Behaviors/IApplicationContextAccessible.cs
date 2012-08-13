using juipp.Controllers;


namespace juipp.Behaviors
{
    public interface IApplicationContextAccessible
    {
        IApplicationContext ActionContext { get;  set; }
    }
}