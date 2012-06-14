using System;

namespace sp.jui.Controllers
{
    public interface IApplicationContext
    {
        string this[String key] { get; set; }
    }
}