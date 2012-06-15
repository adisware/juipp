using System;
using juip.Commons;

namespace juip.app.ViewModels
{
    [Serializable]
    public class CourseViewModel : IViewModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}