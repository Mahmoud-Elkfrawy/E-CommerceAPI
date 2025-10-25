using Microsoft.EntityFrameworkCore;

namespace Depitest.Model
{


    public class AppDBContext : DbContext
    {
        public virtual DbSet<Categoray> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoray>().HasData(
                new Categoray {Id= 1, Name = "Electronics" },
                new Categoray {Id = 2, Name = "Jewelery" },
                new Categoray {Id = 3, Name = "Men's Clothing" },
                new Categoray {Id = 4, Name = "Women's Clothing" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "Mahmoud", Password = "123123", IsAdmin = true },
                new User { Id = 2, UserName = "Ahmed", Password = "123456", IsAdmin = true },
                new User { Id = 3, UserName = "Goda", Password = "123456789", IsAdmin = true },
                new User { Id = 4, UserName = "Yosif", Password = "123456sdsd", IsAdmin = false },
                new User { Id = 5, UserName = "Yosif123", Password = "123456sdsdfdd", IsAdmin = false },
                new User { Id = 6, UserName = "Yosif455", Password = "123456sdsdfdd", IsAdmin = false }
                );


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1000, Description = "Good Laptop", quantity=2, ImageAddress = "", CategoryId = 1 },
                new Product { Id = 2, Name = "Phone", Price = 500, Description = "Good Phone", quantity = 2, ImageAddress = "", CategoryId = 2 },
                new Product { Id = 3, Name = "Headphone", Price = 200, Description = "Good Headphone", quantity = 2, ImageAddress = "", CategoryId = 3 },
                new Product { Id = 4, Name = "Mouse", Price = 100, Description = "Good Mouse", quantity = 2, ImageAddress = "", CategoryId = 2 }
                );
        }
    }

}

