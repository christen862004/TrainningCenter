using System.ComponentModel.DataAnnotations.Schema;

namespace TrainningCenter.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Hours { get; set; }
        public int MinDegree { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Department")]
        public int DeptartmentId { get; set; }
        public Department Department { get; set; }


        public List<CourseResult> CoursesResults { get; set; }
    }
}
