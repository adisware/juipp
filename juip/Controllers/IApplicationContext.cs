using System;

namespace juip.Controllers
{
    public interface IApplicationContext
    {
        string this[String key] { get; set; }
    }
}