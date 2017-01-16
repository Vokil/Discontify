namespace Discountify.Data
{
    using Core.Audit;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class DiscountifyContext : IdentityDbContext<User>, IDiscountifyContext
    {
        public DiscountifyContext(DbContextOptions<DiscountifyContext> options)
            : base(options) { }

        public DiscountifyContext() {}

        public IAuditProvider AuditProvider { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            this.ProcessAuditedEntities();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ProcessAuditedEntities();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessAuditedEntities()
        {
            var addedAuditedEntities = this.ChangeTracker.Entries<IAuditEntity>()
              .Where(p => p.State == EntityState.Added)
              .Select(p => p.Entity);

            var modifiedAuditedEntities = this.ChangeTracker.Entries<IAuditEntity>()
              .Where(p => p.State == EntityState.Modified)
              .Select(p => p.Entity);

            var now = DateTime.UtcNow;

            foreach (var added in addedAuditedEntities)
            {
                added.CreatedAt = now;
                added.CreatedBy = this.AuditProvider.UserId;

                added.LastModifiedAt = now;
                added.LastModifiedBy = added.CreatedBy;
            }

            foreach (var modified in modifiedAuditedEntities)
            {
                modified.LastModifiedAt = now;
                modified.LastModifiedBy = this.AuditProvider.UserId;
            }
        }
    }
}
