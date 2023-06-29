using Pazar4.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.StaticDb.Criterias
{
    public class SellerCriteria
        : ICriteria
    {
        public int Skip { get; set; } = 0;

        public int Take { get; set; } = 10;
    }
}
