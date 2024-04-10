using DemoWebApp.Domain.Entities.Mssql;
using DemoWebApp.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApp.Infrastructure.Persistence
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options) : base(options) { }

        #region DbSet
        public virtual DbSet<UserEntity> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
