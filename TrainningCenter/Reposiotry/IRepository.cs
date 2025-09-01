using TrainningCenter.Models;

namespace TrainningCenter.Reposiotry
{
    public interface IRepository<T> where T:class
    {
        List<T> GetAll(string includes = "");
        T GetById(int id);
        void Add(T obj);
        void Edit(T obj);
        void Delete(int id);
        void Save();
    }
}
