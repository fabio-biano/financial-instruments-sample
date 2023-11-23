namespace FinancialInstruments.Infrastructure.Contracts
{
    public interface IDbContext : IDisposable
    {
        DbSet<FinancialInstrumentCategory> FinancialInstrumentCategories { get; }

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}