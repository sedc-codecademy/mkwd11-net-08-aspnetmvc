using Pazar4.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.StaticDb
{
    public static class Pazar4Db
    {
        public static ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        
        public static ICollection<Listing> Listings { get; set; } = new List<Listing>();
    }
}
