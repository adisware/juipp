using System;
using Org.Juipp.Core.ViewModels;

namespace WebApplication1._layouts.ViewModels 
{
    public static class ViewModelReference
    {
             public const string Default1ViewModel = "Default1ViewModel";
             public const string DefaultViewModel = "DefaultViewModel";
                 }

     
    
    [Serializable]
    public partial class Default1ViewModel : IViewModel {}
  
    
    [Serializable]
    public partial class DefaultViewModel : IViewModel {}
 } 

