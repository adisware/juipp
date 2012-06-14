using System.Collections.Generic;
using sp.jui.Commons;

namespace sp.jui.Controllers
{
    public interface IDetermineModels
    {
        IList<IModel> Models { get; }  
    }
}