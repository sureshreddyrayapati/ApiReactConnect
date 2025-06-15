using Microsoft.EntityFrameworkCore;

namespace ReactApi.Model
{
    public class ReactApiDbContext : DbContext 
    {
        public ReactApiDbContext(DbContextOptions<ReactApiDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
