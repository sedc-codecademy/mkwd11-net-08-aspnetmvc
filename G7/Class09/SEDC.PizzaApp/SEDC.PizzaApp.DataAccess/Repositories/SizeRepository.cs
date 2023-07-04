using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.DataAccess.Storage;
using SEDC.PizzaApp.DomainModels;

namespace SEDC.PizzaApp.DataAccess.Repositories
{
    public class SizeRepository : IRepository<Size>
    {
        public List<Size> GetAll()
        {
            return PizzaDb.Sizes;
        }

        public Size GetById(int id)
        {
            var size = PizzaDb.Sizes.FirstOrDefault(x => x.Id == id);

            if(size == null)
            {
                throw new Exception($"Entity with id {id} is not found.");
            }

            return size; 
        }

        public void Insert(Size entity)
        {
            //Guid.NewGuid();
            //1, 10, 11
            int maxId = PizzaDb.Sizes.Max(x => x.Id);
            entity.Id = maxId + 1;

            PizzaDb.Sizes.Add(entity);
        }

        public void Update(Size entity)
        {
            var size = PizzaDb.Sizes.FirstOrDefault(x => x.Id == entity.Id);

            if (size == null)
            {
                throw new Exception($"Entity with id {entity.Id} is not found.");
            }

            size.Name = entity.Name;
            size.Description = entity.Description;
        }

        public void Delete(Size entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteById(int id)
        {
            var existingSize = PizzaDb.Sizes.FirstOrDefault(x => x.Id == id);

            if (existingSize == null)
            {
                throw new Exception($"Size with id {id} does not exist");
            }

            PizzaDb.Sizes.Remove(existingSize);
        }
    }
}
