using juip.Controllers;


namespace juip.Behaviors
{
    public interface IApplicationContextAccessible
    {
        IApplicationContext ActionContext { get;  set; }
    }
}