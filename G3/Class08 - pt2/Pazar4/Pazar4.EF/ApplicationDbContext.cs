using Microsoft.EntityFrameworkCore;
using Pazar4.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazar4.EF
{
    public class ApplicationDbContext
        : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Listing> Listings { get; set; }
    }
}
