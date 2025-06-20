using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
    public class ERPContext : DbContext
    {
        public ERPContext(DbContextOptions<ERPContext> options)
        : base(options)
                {

        }
        public DbSet<Material> Materials { get; set; }
        public DbSet<UOM> UOM { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
    }
}
