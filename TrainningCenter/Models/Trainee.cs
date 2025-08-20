using System.ComponentModel.DataAnnotations.Schema;

namespace TrainningCenter.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }


        [ForeignKey("Department")]
        public int DeptartmentId { get; set; }
        public Department Department { get; set; }

        public List<CourseResult> CoursesResults { get; set; }
    }
}
