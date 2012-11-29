using System;
using adisware.juipp.ViewModels;

namespace ItemTemplate1.ViewModels 
{
    public static class ViewModelReference
    {
             public const string DefaultViewModel = "DefaultViewModel";
                 }

     
    
    [Serializable]
    public partial class DefaultViewModel : IViewModel {}
 } 

