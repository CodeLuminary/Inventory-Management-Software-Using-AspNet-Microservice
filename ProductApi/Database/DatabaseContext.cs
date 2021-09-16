using Microsoft.EntityFrameworkCore;

namespace ProductApi.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContext) : base(dbContext)
        {
           
        }
        public DbSet<Products> products { get; set; }
    }
}
