﻿using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.Shared.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.DataAccess.EFImplementations
{
    public class OrderEFRepository : IRepository<Order>
    {
        private PizzaAppDbContext _dbContext;

        public OrderEFRepository(PizzaAppDbContext dbContext) //Dependency injection
        {
            _dbContext = dbContext;
        }

        public void Delete(Order entity) 
        {
            _dbContext.Orders.Remove(entity);
            _dbContext.SaveChanges(); //changes will be sent to db
        }

        public List<Order> GetAll()
        {
            /*
             select *
            from Orders as o
            inner join
            Users as u
            on o.UserId = u.Id
            inner join PizzaOrder as po
            on po.OrderId = o.Id
            inner join Pizzas as p
            on p.Id = po.PizzaId
             */

            //this only returns what's in Orders table (without joins)
            //return _dbContext.Orders.ToList();

            return _dbContext.Orders
                .Include(x => x.User) //join with table Users
                .Include(x => x.PizzaOrders) //join with table PizzaOrder
                .ThenInclude(x => x.Pizza) //now join PizzaOrder with Pizzas
                .ToList();

        }

        public Order GetById(int id)
        {
            return _dbContext.Orders
                .Include(x => x.PizzaOrders) //join PizzaOrder
                .ThenInclude(x => x.Pizza) // make join between PizzaOrder and Pizzas
                .Include(x => x.User) // join Orders with Users
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Order entity)
        {
            //ids are generated by the db, because the Id columns are marked as Identity
            _dbContext.Orders.Add(entity); //still changes aren't pushed to db
            _dbContext.SaveChanges(); //now changes will be applied
        }

        public void Update(Order entity)
        {
            //we know that we have validation in the service

            //Order orderDb = _dbContext.Orders.FirstOrDefault(o => o.Id == entity.Id);
            //if (orderDb == null)
            //{
            //    throw new ResourceNotFoundException($"Order with id {entity.Id} was not found in db.");
            //}

            _dbContext.Orders.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
