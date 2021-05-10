using Microsoft.EntityFrameworkCore;
using MyFirstApi.Entities;

namespace MyFirstApi
{
    public class MyFirstApiContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public MyFirstApiContext(DbContextOptions options)
            :base(options)
        {

        }
    }
}
