using System.Collections.Generic;
using juip.Commons;

namespace juip.Controllers
{
    public interface IDetermineModels
    {
        IList<IViewModel> Models { get; }  
    }
}