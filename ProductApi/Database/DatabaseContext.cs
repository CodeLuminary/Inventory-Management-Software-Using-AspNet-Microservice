using Microsoft.EntityFrameworkCore;

namespace ProductApi.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Products> products { get; set; }
    }
}
