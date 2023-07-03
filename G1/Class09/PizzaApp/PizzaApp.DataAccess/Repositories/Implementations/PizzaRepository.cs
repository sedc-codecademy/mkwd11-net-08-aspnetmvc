namespace PizzaApp.DataAccess.Repositories.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using PizzaApp.DataAccess.DataContext;
    using PizzaApp.DataAccess.Repositories.Interfaces;
    using PizzaApp.Domain.Models;

    public class PizzaRepository : IRepository<Pizza>
    {
        private PizzaAppDbContext _dbContext;

        public PizzaRepository(PizzaAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<int> DeleteById(int id)
        {
            Pizza pizzaDb = await _dbContext.Pizzas
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pizzaDb == null)
            {
                throw new Exception($"Item with Id:{id} not found.");
            }

            _dbContext.Pizzas.Remove(pizzaDb);
            await _dbContext.SaveChangesAsync();

            return pizzaDb.Id;
        }

        public async Task<List<Pizza>> GetAll()
        {
            return await _dbContext.Pizzas.ToListAsync();
        }

        public async Task<Pizza> GetById(int id)
        {
            return await _dbContext.Pizzas
                .Include(x=>x.PizzaOrders)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Insert(Pizza entity)
        {
            await _dbContext.Pizzas.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Pizza entity)
        {
            _dbContext.Pizzas.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
