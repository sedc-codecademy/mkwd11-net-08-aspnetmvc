﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.PizzaApp.DataAccess;

#nullable disable

namespace SEDC.PizzaApp.DataAccess.Migrations
{
    [DbContext(typeof(PizzaAppDbContext))]
    [Migration("20230706160021_NewMenuItemAdded")]
    partial class NewMenuItemAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SEDC.PizzaApp.DomainModels.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.HasIndex("SizeId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PizzaId = 1,
                            Price = 150m,
                            SizeId = 1
                        },
                        new
                        {
                            Id = 2,
                            PizzaId = 1,
                            Price = 230m,
                            SizeId = 2
                        },
                        new
                        {
                            Id = 3,
                            PizzaId = 1,
                            Price = 300m,
                            SizeId = 3
                        },
                        new
                        {
                            Id = 4,
                            PizzaId = 1,
                            Price = 400m,
                            SizeId = 4
                        },
                        new
                        {
                            Id = 5,
                            PizzaId = 2,
                            Price = 180m,
                            SizeId = 1
                        },
                        new
                        {
                            Id = 6,
                            PizzaId = 2,
                            Price = 260m,
                            SizeId = 2
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.DomainModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SEDC.PizzaApp.DomainModels.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("SEDC.PizzaApp.DomainModels.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Kecap, kaskaval, pecurki, shunka",
                            ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/0e/25/5c/f9/pizza-capricciosa-pica.jpg",
                            Name = "Kaprichioza"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Kecap, kaskaval, pecurki, shunka, pavlaka",
                            ImageUrl = "https://media.istockphoto.com/id/510306420/photo/pizza-with-loin-sour-cream-and-mushrooms.jpg?s=612x612&w=0&k=20&c=d9iT9uW7aJ04jt57PdUp3s5917JeSwY6pE6AouHeMCw=",
                            Name = "Stelato"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Kecap, kaskaval, pecurki, kulen",
                            ImageUrl = "https://www.simplehomecookedrecipes.com/wp-content/uploads/2021/02/Pepperoni-Pizza-480x270.png",
                            Name = "Pepperoni"
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.DomainModels.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Diameter")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "20 cm",
                            Diameter = 0,
                            Name = "Small"
                        },
                        new
                        {
                            Id = 2,
                            Description = "30 cm",
                            Diameter = 0,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Description = "40 cm",
                            Diameter = 0,
                            Name = "Large"
                        },
                        new
                        {
                            Id = 4,
                            Description = "50 cm",
                            Diameter = 0,
                            Name = "Family"
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.DomainModels.MenuItem", b =>
                {
                    b.HasOne("SEDC.PizzaApp.DomainModels.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.PizzaApp.DomainModels.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("SEDC.PizzaApp.DomainModels.OrderItem", b =>
                {
                    b.HasOne("SEDC.PizzaApp.DomainModels.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.PizzaApp.DomainModels.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SEDC.PizzaApp.DomainModels.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
