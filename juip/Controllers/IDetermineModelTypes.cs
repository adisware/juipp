using System.Collections.Generic;
using juipp.Commons;

namespace juipp.Controllers
{
    public interface IDetermineModels
    {
        IList<IViewModel> Models { get; }  
    }
}