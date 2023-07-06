using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DataAccess.Repositories
{
    public class MenuItemRepository : IRepository<MenuItem>
    {
        private PizzaAppDbContext _dbContext;

        public MenuItemRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(MenuItem entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public MenuItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(MenuItem entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MenuItem> Query()
        {
            return _dbContext.MenuItems;
        }

        public void Update(MenuItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
