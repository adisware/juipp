using System;
using juip.Commons;

namespace juip.app.ViewModels
{
    public partial class StudentViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}