namespace TrainningCenter.ViewModels
{
    public class AllTraineeResultViewModel
    {
        public int TraineeId { get; set; }
        public string TraineeName { get; set; }

        public List<ColoredCourseResultViewModel> CourseResults { get; set; }
    }
}
