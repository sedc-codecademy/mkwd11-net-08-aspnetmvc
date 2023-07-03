using Pazar4.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.DAL.Repository
{
    public class ListingCriteria
        : ICriteria
    {
        public string Search { get; set; } = string.Empty;

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public int Skip { get; set; } = 0;

        public int Take { get; set; } = 10;

        //public Expression<Func<Listing, object>> OrderBy { get; set; }
    }
}
