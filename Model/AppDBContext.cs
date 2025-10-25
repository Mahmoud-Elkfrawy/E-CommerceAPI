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
    }

}

