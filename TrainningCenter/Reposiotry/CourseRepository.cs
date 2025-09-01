using TrainningCenter.Models;

namespace TrainningCenter.Reposiotry
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly CenterContext context;

        public CourseRepository(CenterContext _context):base(_context)
        {
            context = _context;
        }
    }
}
