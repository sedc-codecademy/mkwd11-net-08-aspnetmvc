﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.PizzaApp.Refactored.DataAccess;

#nullable disable

namespace SEDC.PizzaApp.Refactored.DataAccess.Migrations
{
    [DbContext(typeof(PizzaAppDbContext))]
    partial class PizzaAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SEDC.PizzaApp.Refactored.Domain.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDelivered = true,
                            PaymentMethod = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsDelivered = false,
                            PaymentMethod = 1,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Refactored.Domain.Orders.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumberOfPizzas")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NumberOfPizzas = 1,
                            OrderId = 1,
                            PizzaId = 1,
                            PizzaSize = 1
                        },
                        new
                        {
                            Id = 2,
                            NumberOfPizzas = 2,
                            OrderId = 1,
                            PizzaId = 2,
                            PizzaSize = 2
                        },
                        new
                        {
                            Id = 3,
                            NumberOfPizzas = 1,
                            OrderId = 2,
                            PizzaId = 2,
                            PizzaSize = 2
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Refactored.Domain.Pizzas.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsOnPromotion")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsOnPromotion = true,
                            Name = "Capri",
                            Price = 400
                        },
                        new
                        {
                            Id = 2,
                            IsOnPromotion = false,
                            Name = "Pepperoni",
                            Price = 350
                        },
                        new
                        {
                            Id = 3,
                            IsOnPromotion = false,
                            Name = "Margarita",
                            Price = 350
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Refactored.Domain.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Bob Street 22",
                            FirstName = "Bob",
                            LastName = "Bobsky",
                            PhoneNumber = "111"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Wayne Street 33",
                            FirstName = "Jill",
                            LastName = "Wayne",
                            PhoneNumber = "222"
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Refactored.Domain.Orders.Order", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Refactored.Domain.Users.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Refactored.Domain.Orders.PizzaOrder", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Refactored.Domain.Orders.Order", "Order")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.PizzaApp.Refactored.Domain.Pizzas.Pizza", "Pizza")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Refactored.Domain.Orders.Order", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Refactored.Domain.Pizzas.Pizza", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("SEDC.PizzaApp.Refactored.Domain.Users.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}