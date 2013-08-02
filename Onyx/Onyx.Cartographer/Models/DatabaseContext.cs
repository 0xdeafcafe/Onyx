using System.Data.Entity;

namespace Onyx.Cartographer.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
