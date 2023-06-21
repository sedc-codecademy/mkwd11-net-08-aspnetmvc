using PizzaApp.Refactored._07.Domain;

namespace PizzaApp.Refactored._07.DataAccess
{
    public interface IRepository<T> where T :  BaseEntity
    {
        //CRUD methods
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void Update(T entity);
        void DeleteById(int id);
    }
}
