using System.Collections.Generic;
using juip.Commons;

namespace sp.jui.Controllers
{
    public interface IDetermineModels
    {
        IList<IViewModel> Models { get; }  
    }
}