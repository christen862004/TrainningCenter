using System.ComponentModel.DataAnnotations.Schema;

namespace TrainningCenter.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public int TraineeDegree { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
