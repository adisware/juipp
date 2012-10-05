using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adisware.juipp.Web._layouts.app.ViewModels
{
    /** StudentViewModel
     * Example of ViewModel representating a data subset of a Student 
     * and logical flag determining edit capabilities
     */
    public partial class StudentViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsInEditMode { get; set; }
    }
}