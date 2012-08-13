using System;

namespace juipp.Controllers
{
    public interface IApplicationContext
    {
        object this[String key] { get; set; }
    }
}