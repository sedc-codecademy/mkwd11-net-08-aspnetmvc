using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Refactored.Domain.Enums;
using SEDC.PizzaApp.Refactored.Domain.Models;

namespace SEDC.PizzaApp.Refactored.DataAccess.Data
{
    //Microsoft.EntityFrameworkCore
    //Microsoft.EntityFrameworkCore.Design
    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.Tools
    public class PizzaAppDbContext : DbContext
    {
        public PizzaAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Defining relations 
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

            // Seeding
            modelBuilder.Entity<Pizza>()
                .HasData(
                    new Pizza
                    {
                        Id = 1,
                        Name = "Cappricioza",
                        IsOnPromotion = true
                    },
                    new Pizza
                    {
                        Id = 2,
                        Name = "Pepperoni",
                        IsOnPromotion = false
                    },
                    new Pizza
                    {
                        Id = 3,
                        Name = "Margarita",
                        IsOnPromotion = false
                    }
                );

            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Address = "Bob Street 22"
                },
                    new User
                    {
                        Id = 2,
                        FirstName = "Jill",
                        LastName = "Wayne",
                        Address = "Wayne Street 33"
                    }
                );

            modelBuilder.Entity<Order>()
                .HasData(
                    new Order
                    {
                        Id = 1,
                        PaymentMethod = PaymentMethod.Card,
                        Delivered = true,
                        Location = "Store1",
                        UserId = 1
                    },
                    new Order
                    {
                        Id = 2,
                        PaymentMethod = PaymentMethod.Cash,
                        Delivered = false,
                        Location = "Store2",
                        UserId = 2
                    }
                );

            modelBuilder.Entity<PizzaOrder>()
                .HasData(
                new PizzaOrder
                {
                    Id = 1,
                    OrderId = 1,
                    PizzaId = 1,
                    PizzaSize = PizzaSize.Standard
                },
                    new PizzaOrder
                    {
                        Id = 2,
                        OrderId = 1,
                        PizzaId = 2,
                        PizzaSize = PizzaSize.Family
                    },
                     new PizzaOrder
                     {
                         Id = 3,
                         OrderId = 2,
                         PizzaId = 2,
                         PizzaSize = PizzaSize.Family
                     }
                 );
        }
    }
}
