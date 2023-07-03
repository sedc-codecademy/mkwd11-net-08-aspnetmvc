using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PizzaAppRefactored.Domain.Enums;
using PizzaAppRefactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.DataAccess
{
    //Context class has to inherit from DbContext
    public class PizzaAppDbContext : DbContext
    {
        //through the options param we get different info for the configuration of the db connection (for example connection string)
        public PizzaAppDbContext(DbContextOptions options) : base(options) { }  

        //define main tables (domain classes that you want to map into tables)
        //you don't need to specify tables for many-to-many relationship
        public DbSet<Pizza> Pizzas { get; set; }    
        public DbSet<Order> Orders { get; set; }    
        public DbSet<User> Users { get; set; }

        //defining relations, eventually adding initial data in the db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //define relations

            modelBuilder.Entity<Pizza>() //the main table
                .HasMany(x => x.PizzaOrders) //one pizza is related with many records in the PizzaOrder table
                .WithOne(x => x.Pizza) //one PizzaOrder is related to one record in the Pizza table
                .HasForeignKey(x => x.PizzaId);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            //modelBuilder.Entity<Order>() 
            //    .HasOne(x => x.User) //one Order is related to one record in the User table
            //    .WithMany(x => x.Orders) //one user can be related to many records in the Orders table
            //    .HasForeignKey(x => x.UserId); 

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders) //1-m relationship (many side)
                .WithOne(x => x.User) //1-m relationship (one side)
                .HasForeignKey(x => x.UserId); //foreign key in the relationship

            modelBuilder.Entity<Pizza>()
                .HasData(new Pizza
                {

                    Id = 1,
                    Name = "Capricciosa",
                    IsOnPromotion = true
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Pepperoni",
                    IsOnPromotion = false
                }
                );

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Tijana",
                    LastName = "Stojanovska",
                    Address = "Address1",
                },
                 new User
                 {
                     Id = 2,
                     FirstName = "Aleksandar",
                     LastName = "Ivanovski",
                     Address = "Address2",
                 }
                );

            modelBuilder.Entity<Order>()
                .HasData(
                 new Order
                 {
                     Id = 1,
                     PizzaStore = "Jakomo",
                     IsDelivered = false,
                     PaymentMethod = PaymentMethodEnum.Card,
                     UserId = 1
                 },

                 new Order
                 {
                     Id = 2,
                     PizzaStore = "Jakomo",
                     IsDelivered = false,
                     PaymentMethod = PaymentMethodEnum.Cash,
                     UserId = 2
                 }

                );

            modelBuilder.Entity<PizzaOrder>()
                .HasData(
                new PizzaOrder
                {
                    Id = 1,
                    PizzaId = 1,
                    Price = 350,
                    Quantity = 1,
                    OrderId = 2,
                    PizzaSize = PizzaSizeEnum.Standard
                },
                new PizzaOrder
                {
                    Id = 2,
                    PizzaId = 2,
                    Price = 300,
                    Quantity = 1,
                    OrderId = 1,
                    PizzaSize = PizzaSizeEnum.Standard
                }
                );

        }
    }
}
