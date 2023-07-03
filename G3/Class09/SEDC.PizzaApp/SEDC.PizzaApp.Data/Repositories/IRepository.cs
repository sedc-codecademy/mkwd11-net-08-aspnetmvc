using SEDC.PizzaApp.Data.Models;

namespace SEDC.PizzaApp.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll();

        public T? GetById(int id);

        public void Save(T entity);

        public void Update(T entity);

        public void Delete(T entity);
    }
}
