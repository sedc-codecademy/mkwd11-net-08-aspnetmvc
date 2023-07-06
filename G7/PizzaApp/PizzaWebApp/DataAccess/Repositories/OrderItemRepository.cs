using DataAccess.Abstraction;
using DomainModels;

namespace DataAccess.Repositories
{
    public class OrderItemRepository : IRepository<OrderItem>
    {
        private readonly PizzaAppDbContext _dbContext;

        public OrderItemRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(OrderItem entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
