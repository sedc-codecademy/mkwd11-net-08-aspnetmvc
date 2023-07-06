using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.DomainModels;

namespace SEDC.PizzaApp.DataAccess.Repositories
{
    public class SizeEfRepository : IRepository<Size>
    {
        private PizzaAppDbContext _dbContext;

        public SizeEfRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Size> Query()
        {
            return _dbContext.Sizes;
        }

        public List<Size> GetAll()
        {
            var sizes = _dbContext.Sizes.ToList();

            return sizes;
        }

        public Size GetById(int id)
        {
            //Select Top 1 * From Sizes Where Id = 4
            var size = _dbContext.Sizes.FirstOrDefault(x => x.Id == id);

            if(size == null)
            {
                throw new Exception("Entity with that id, does not exist");
            }

            return size;
        }

        public void Insert(Size entity)
        {
            _dbContext.Sizes.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Size entity)
        {
            _dbContext.Sizes.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(Size entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteById(int id)
        {
            //var size = _dbContext.Sizes.FirstOrDefault(x => x.Id == id);

            //if (size == null)
            //{
            //    throw new Exception("Entity with that id, does not exist");
            //}

            var size = GetById(id);
            _dbContext.Sizes.Remove(size);
            _dbContext.SaveChanges();
        }
    }
}
