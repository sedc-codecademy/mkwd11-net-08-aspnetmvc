using SEDC.PizzaApp.Refactored.Domain;

namespace SEDC.PizzaApp.Refactored.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        //CRUD methods
        List<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
