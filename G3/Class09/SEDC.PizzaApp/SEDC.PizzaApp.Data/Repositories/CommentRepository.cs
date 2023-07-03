using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Data.Database;
using SEDC.PizzaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Data.Repositories
{
    public class CommentRepository
        : IRepository<Comments>
    {
        private readonly ApplicationDbContext dbContext;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Save(Comments entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Comments entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<Comments> GetAll()
        {
            return dbContext.Comments.AsNoTracking();
        }

        public Comments? GetById(int id)
        {
            return dbContext.Comments.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Comments entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
