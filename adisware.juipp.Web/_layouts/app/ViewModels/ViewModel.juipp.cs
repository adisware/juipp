using System;
using adisware.juipp.ViewModels;

namespace adisware.juipp.Web._layouts.app.ViewModels 
{
    public static class ViewModelReference
    {
             public const string MyViewModel = "adisware.juipp.Web._layouts.app.ViewModels.MyViewModel";
             public const string StudentViewModel = "adisware.juipp.Web._layouts.app.ViewModels.StudentViewModel";
                 }

     
    
    [Serializable]
    public partial class MyViewModel : IViewModel {}
  
    
    [Serializable]
    public partial class StudentViewModel : IViewModel {}
 } 

