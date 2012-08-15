using System;

namespace adisware.juipp.Controllers
{
    public interface IBehaviorContext
    {
        object this[String key] { get; set; }
    }
}