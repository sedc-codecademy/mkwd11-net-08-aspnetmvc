namespace PizzaApp.DataAccess.DataContext
{
    using Microsoft.EntityFrameworkCore;
    using PizzaApp.Domain.Models;

    public class PizzaAppDbContext : DbContext
    {
        public PizzaAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Pizza>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Pizza)
                .HasForeignKey(x => x.PizzaId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Pizza>()
                .HasData(new Pizza
                {
                    Id = 1,
                    IsOnPromotion = false,
                    Name="Capriciosa"
                },
                new Pizza
                {
                    Id = 2,
                    IsOnPromotion = true,
                    Name = "Oliva"
                },
                new Pizza
                {
                    Id = 3,
                    IsOnPromotion = true,
                    Name = "Mexicana"
                },
                new Pizza
                {
                    Id = 4,
                    IsOnPromotion = false,
                    Name = "Pepperoni"
                });
        }
    }
}
