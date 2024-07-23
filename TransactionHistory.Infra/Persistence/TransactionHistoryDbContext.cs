using Microsoft.EntityFrameworkCore;
using TransactionHistory.Core.DomainObjects;

namespace TransactionHistory.Infra.Persistence
{
    public class TransactionHistoryDbContext : DbContext
    {
        public TransactionHistoryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransactionHistoryDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> CommitAsync()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(nameof(Entity.CreatedAt)) != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameof(Entity.CreatedAt)).CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(Entity.UpdatedAt)).CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
