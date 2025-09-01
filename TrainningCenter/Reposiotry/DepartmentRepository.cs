using TrainningCenter.Models;

namespace TrainningCenter.Reposiotry
{
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository
    {
        private readonly CenterContext context;

        public DepartmentRepository(CenterContext context):base(context)
        {
            this.context = context;
        }
    }
}
