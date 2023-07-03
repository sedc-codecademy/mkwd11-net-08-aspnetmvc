using Pazar4.DAL.Entities;
using Pazar4.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.StaticDb.Repository
{
    public class ListingRepository
        : IRepository<Listing, ListingCriteria>
    {
        public void Create(Listing entity)
        {
            throw new NotImplementedException();
        }

        //Criteria - one way
        public IEnumerable<Listing> GetAll(ListingCriteria criteria)
        {
            IEnumerable<Listing> query = Pazar4Db.Listings;
            if (!string.IsNullOrEmpty(criteria.Search))
            {
                query = query.Where(x => x.Title.Contains(criteria.Search));
            }
            return query.Skip(criteria.Skip).Take(criteria.Take)
                .AsQueryable();
        }

        public Listing? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
