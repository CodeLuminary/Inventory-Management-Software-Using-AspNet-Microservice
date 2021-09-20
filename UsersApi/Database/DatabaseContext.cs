using Microsoft.EntityFrameworkCore;

namespace UsersApi.Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<Users> users { get; set; }
        public DbSet<UserLogHistory> userLogHistory { get; set; }
    }
}
