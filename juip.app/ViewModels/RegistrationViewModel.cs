using System;
using juip.Commons;

namespace juip.app.ViewModels
{
    [Serializable]
    public class RegistrationViewModel  : IViewModel
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
    }
}