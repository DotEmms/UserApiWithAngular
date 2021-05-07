using Microsoft.EntityFrameworkCore;

namespace MyFirstApi
{
    public class MyFirstApiContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public MyFirstApiContext(DbContextOptions options)
            :base(options)
        {

        }
    }
}
