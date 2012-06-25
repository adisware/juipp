using System;

namespace juip.Controllers
{
    public interface IApplicationContext
    {
        object this[String key] { get; set; }
    }
}