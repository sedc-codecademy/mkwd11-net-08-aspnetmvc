using Pazar4.DAL.Entities;
using Pazar4.DAL.Repository;
using Pazar4.StaticDb.Criterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.StaticDb.Repository
{
    public class SellerRepository
        : IRepository<Seller, SellerCriteria>
    {
        public void Create(Seller entity)
        {
            entity.Id = Pazar4Db.Sellers.Count  == 0 ? 1 : Pazar4Db.Sellers.Max(x => x.Id) + 1;
            Pazar4Db.Sellers.Add(entity);
        }

        public IEnumerable<Seller> GetAll(SellerCriteria criteria)
        {
            return Pazar4Db.Sellers.Skip(criteria.Skip).Take(criteria.Take);
        }

        public Seller? GetById(int id)
        {
            return Pazar4Db.Sellers.SingleOrDefault(x => x.Id == id);
        }
    }
}
