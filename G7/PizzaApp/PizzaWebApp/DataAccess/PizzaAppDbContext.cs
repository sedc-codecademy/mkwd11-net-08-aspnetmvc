using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class PizzaAppDbContext : DbContext
    {
        public PizzaAppDbContext(DbContextOptions<PizzaAppDbContext> options) : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pizza>(x => x.ToTable("Pizza"));
            /*.Property(x => x.ImageUrl).HasColumnName("URL").HasColumnType("nvarchar(100)")*/
            builder.Entity<Size>(x => x.ToTable("Size"));
            builder.Entity<MenuItem>(x => x.ToTable("MenuItem"));
            builder.Entity<OrderItem>(x => x.ToTable("OrderItem"));
            builder.Entity<Order>(x => x.ToTable("Order")
            .HasMany(y => y.OrderItems)
            .WithOne(z => z.Order)
            .HasForeignKey(t => t.OrderId));

            //Seed
            builder.Entity<Pizza>().HasData(
                    new Pizza("Kapricioza", "Kecap, kaskaval, pecurki, shunka", "https://media-cdn.tripadvisor.com/media/photo-s/0e/25/5c/f9/pizza-capricciosa-pica.jpg")
                    {
                        Id = 1
                    },
                    new Pizza("Peperoni", "Kecap, kaskaval, pecurki, kulen", "https://www.simplehomecookedrecipes.com/wp-content/uploads/2021/02/Pepperoni-Pizza-480x270.png")
                    {
                        Id = 2
                    }
                );

            builder.Entity<Size>().HasData(
                    new Size("Mala", "20 cm")
                    {
                        Id = 1
                    },
                    new Size("Sredna", "30 cm")
                    {
                        Id = 2
                    },
                    new Size("Golema", "40 cm")
                    {
                        Id = 3
                    },
                    new Size("Familijarna", "50 cm")
                    {
                        Id = 4
                    }
                );

            builder.Entity<MenuItem>().HasData(
                    new MenuItem(1, 1, 150)
                    {
                        Id = 1
                    },
                    new MenuItem(1, 2, 230)
                    {
                        Id = 2
                    },
                    new MenuItem(1, 3, 300)
                    {
                        Id = 3
                    },
                    new MenuItem(1, 4, 400)
                    {
                        Id = 4
                    },
                    new MenuItem(2, 1, 180)
                    {
                        Id = 5
                    },
                    new MenuItem(2, 2, 250)
                    {
                        Id = 6
                    },
                    new MenuItem(2, 3, 320)
                    {
                        Id = 7
                    },
                    new MenuItem(2, 4, 420)
                    {
                        Id = 8
                    }
                );
        }
    }
}
