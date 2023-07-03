using Pazar4.DAL.Entities;
using Pazar4.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.EF.Repository
{
    public class SellerRepository
        //: IRepository<Seller, ListingCriteria>
    {
        private readonly ApplicationDbContext context;

        public SellerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Seller entity)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Seller> GetAll(ListingCriteria criteria)
        //{
        //    IQueryable<Seller>? query = context.Sellers;
        //    if (!string.IsNullOrEmpty(criteria.Search))
        //    {
        //        query = query.Where(x => x.Email.Contains(criteria.Search));
        //    }
        //    return query;
        //}

        public Seller? GetById(int id)
        {
            return context.Sellers.SingleOrDefault(s => s.Id == id);
        }
    }
}
