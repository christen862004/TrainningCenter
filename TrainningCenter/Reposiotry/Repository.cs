
using Microsoft.EntityFrameworkCore;
using TrainningCenter.Models;

namespace TrainningCenter.Reposiotry
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CenterContext context;
        private DbSet<T> EntityName;

        public Repository(CenterContext _context)
        {
            context = _context;
            EntityName = context.Set<T>();
        }
        public void Add(T obj)
        {
            context.Add(obj);
        }

        public void Delete(int id)
        {
            context.Remove(GetById(id));
        }

        public void Edit(T obj)
        {
            context.Update(obj);
        }

        public List<T> GetAll(string includes = "")
        {
            if (includes == "")
            {
                return context.Set<T>().ToList();
            }
            else
            {
                return context.Set<T>().Include(includes).ToList();
            }
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
