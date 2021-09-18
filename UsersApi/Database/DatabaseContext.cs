using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
