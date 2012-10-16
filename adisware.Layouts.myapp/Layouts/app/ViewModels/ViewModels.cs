using System;
using adisware.juipp.ViewModels;

namespace adisware.Layouts.app.ViewModels 
{
    public static class ViewModelReference
    {
             public const string MyViewModel = "MyViewModel";
             public const string ViewModel = "ViewModel";
                 }

     
    
    [Serializable]
    public partial class MyViewModel : IViewModel {}
  
    
    [Serializable]
    public partial class ViewModels : IViewModel {}
 } 

