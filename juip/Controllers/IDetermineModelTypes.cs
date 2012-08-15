using System.Collections.Generic;
using adisware.juipp.Commons;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Controllers
{
    public interface IDetermineModels
    {
        IList<IViewModel> Models { get; }  
    }
}