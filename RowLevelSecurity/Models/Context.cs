using System.Data.Entity;

namespace RowLevelSecurity.Models
{
    public class Context: DbContext
    {
        public Context():base("SecurityRowLevel")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
