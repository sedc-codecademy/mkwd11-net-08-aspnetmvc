using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Refactored.Domain.Enums;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;
using SEDC.PizzaApp.Refactored.Domain.Users;

namespace SEDC.PizzaApp.Refactored.DataAccess
{
    public class PizzaAppDbContext : DbContext
    {
        public PizzaAppDbContext(DbContextOptions options) : base(options)
        { }

        //Define tables

        //this db set tells that we will have Users table with columns from the properties of User class
        //we use the db sets to access tables in the db
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<PizzaOrder> PizzaOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Define the relations
            modelBuilder.Entity<Order>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Pizza>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Pizza)
                .HasForeignKey(x => x.PizzaId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(x => x.User)
            //    .WithMany(x => x.Orders)
            //    .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);


            //Seeding (adding initial data in the tables)
            //Pizzas
            modelBuilder.Entity<Pizza>()
                .HasData
                (
                    new Pizza
                    {
                        Id = 1,
                        IsOnPromotion = true,
                        Name = "Capri",
                        Price = 400
                    },
                    new Pizza
                    {
                        Id = 2,
                        IsOnPromotion = false,
                        Name = "Pepperoni",
                        Price = 350
                    },
                    new Pizza
                    {
                        Id = 3,
                        IsOnPromotion = false,
                        Name = "Margarita",
                        Price = 350
                    }
                );

            //Users
            modelBuilder.Entity<User>()
               .HasData(new User
               {
                   Id = 1,
                   FirstName = "Bob",
                   LastName = "Bobsky",
                   Address = "Bob Street 22",
                   PhoneNumber = "111"
                   
               },
               new User
               {
                   Id = 2,
                   FirstName = "Jill",
                   LastName = "Wayne",
                   Address = "Wayne Street 33",
                   PhoneNumber = "222"
               });

            //Orders
            modelBuilder.Entity<Order>()
               .HasData(new Order
               {
                   Id = 1,
                   PaymentMethod = PaymentMethod.Card,
                   IsDelivered = true,
                   UserId = 1
               },
               new Order
               {
                   Id = 2,
                   PaymentMethod = PaymentMethod.Cash,
                   IsDelivered = false,
                   UserId = 2
               });

            //PizzaOrders
            modelBuilder.Entity<PizzaOrder>()
                .HasData(new PizzaOrder
                {
                    Id = 1,
                    OrderId = 1,
                    PizzaId = 1,
                    PizzaSize = PizzaSize.Standard,
                    NumberOfPizzas = 1
                },
                new PizzaOrder
                {
                    Id = 2,
                    OrderId = 1,
                    PizzaId = 2,
                    PizzaSize = PizzaSize.Family,
                    NumberOfPizzas = 2
                },
                 new PizzaOrder
                 {
                     Id = 3,
                     OrderId = 2,
                     PizzaId = 2,
                     PizzaSize = PizzaSize.Family,
                     NumberOfPizzas = 1
                 });
        }
    }
}
