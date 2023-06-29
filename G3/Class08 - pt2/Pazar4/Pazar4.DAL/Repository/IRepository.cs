using Pazar4.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.DAL.Repository
{
    public interface IRepository<T, K> where T : BaseEntity 
        where K:ICriteria
    {
        T? GetById(int id);

        void Create(T entity);

        IEnumerable<T> GetAll(K criteria);
    }
}
