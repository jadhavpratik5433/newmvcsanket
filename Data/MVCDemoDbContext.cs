using aspMVCproject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace aspMVCproject.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Client>Client { get; set; }

    }
}
