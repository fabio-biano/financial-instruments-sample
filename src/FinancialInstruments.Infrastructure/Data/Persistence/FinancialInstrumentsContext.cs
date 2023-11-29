namespace FinancialInstruments.Infrastructure.Data.Persistence
{
    public class FinancialInstrumentsContext : DbContext, IDbContext
    {
        public FinancialInstrumentsContext(DbContextOptions<FinancialInstrumentsContext> options) : base(options)
        {

        }

        public virtual DbSet<FinancialInstrumentCategory> FinancialInstrumentCategories => Set<FinancialInstrumentCategory>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            // Seed financial instrments categories
            builder.Entity<FinancialInstrumentCategory>().HasData(
                new FinancialInstrumentCategory
                {
                    Id = 1,
                    MinimumMarketValue = 0.00,
                    MaximumMarketValue = 1000000.00,
                    Category = "Low Value"
                });

            builder.Entity<FinancialInstrumentCategory>().HasData(
                new FinancialInstrumentCategory
                {
                    Id = 2,
                    MinimumMarketValue = 1000000.00,
                    MaximumMarketValue = 5000000.00,
                    Category = "Medium Value"
                });

            builder.Entity<FinancialInstrumentCategory>().HasData(
                new FinancialInstrumentCategory
                {
                    Id = 3,
                    MinimumMarketValue = 5000000.00,
                    MaximumMarketValue = double.MaxValue,
                    Category = "High Value"
                });
        }

        public override int SaveChanges() => SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetDefaultsOnChange();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetDefaultsOnChange();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetDefaultsOnChange()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && e.State is EntityState.Added or EntityState.Modified);

            var currentDateTime = DateTime.Now;
            foreach (var entity in entries)
            {
                ((BaseEntity)entity.Entity).UpdatedAt = currentDateTime;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = currentDateTime;
                }
            }
        }
    }
}