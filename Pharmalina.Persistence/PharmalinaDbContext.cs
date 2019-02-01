using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pharmalina.Domain.Entities;
using Pharmalina.Persistence.Extensions;

namespace Pharmalina.Persistence
{
    public class PharmalinaDbContext : IdentityDbContext<User>
    {
        public PharmalinaDbContext(DbContextOptions<PharmalinaDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Lot> Lots { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }*/
    }
}
