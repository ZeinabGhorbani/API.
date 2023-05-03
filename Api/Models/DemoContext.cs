using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
