using System.ComponentModel.DataAnnotations.Schema;
using TrainningCenter.Models;

namespace TrainningCenter.ViewModels
{
    public class NewInstructorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public int Salary { get; set; }
        public string? ImageURL { get; set; }
           
        public int CourseId { get; set; }
        public int DeptartmentId { get; set; }

        public List<Department> DeptList { get; set; }
        public List<Course> CourseList { get; set; }
    }
}
