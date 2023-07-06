using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.DataAccess.Helpers;
using SEDC.PizzaApp.DomainModels;

namespace SEDC.PizzaApp.DataAccess
{
    public class PizzaAppDbContext : DbContext
    {
        public PizzaAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        //DbSet is linked to a table in the database and is used for accessing/manipulating all the data in that table
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Size>(x => x.ToTable("SizeTable").Property(x => x.Description).HasColumnName("Desc"));
            
            //modelBuilder.Entity<Order>()
            //    .HasMany<OrderItem>()
            //    .WithOne(x => x.Order)
            //    .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Size>().HasData(
                new Size(1, "Small", "20 cm"),
                new Size(2, "Medium", "30 cm"),
                new Size(3, "Large", "40 cm"),
                new Size(4, "Family", "50 cm")
                );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza(1, "Kaprichioza", "Kecap, kaskaval, pecurki, shunka", "https://media-cdn.tripadvisor.com/media/photo-s/0e/25/5c/f9/pizza-capricciosa-pica.jpg"),
                new Pizza(2, "Stelato", "Kecap, kaskaval, pecurki, shunka, pavlaka", "https://media.istockphoto.com/id/510306420/photo/pizza-with-loin-sour-cream-and-mushrooms.jpg?s=612x612&w=0&k=20&c=d9iT9uW7aJ04jt57PdUp3s5917JeSwY6pE6AouHeMCw="),
                new Pizza(3, "Pepperoni", "Kecap, kaskaval, pecurki, kulen", "https://www.simplehomecookedrecipes.com/wp-content/uploads/2021/02/Pepperoni-Pizza-480x270.png")
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem(1, 1, 1, 150),
                new MenuItem(2, 1, 2, 230),
                new MenuItem(3, 1, 3, 300),
                new MenuItem(4, 1, 4, 400),
                new MenuItem(5, 2, 1, 180),
                new MenuItem(6, 2, 2, 260)
                );
        }
    }
}
