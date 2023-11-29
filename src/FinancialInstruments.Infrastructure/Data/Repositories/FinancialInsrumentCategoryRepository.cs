namespace FinancialInstruments.Infrastructure.Data.Repositories;

public class FinancialInsrumentCategoryRepository : IFinancialInstrumentCategoryRepository, IDisposable
{
    private readonly IDbContext _dbContext;

    public FinancialInsrumentCategoryRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Delete(FinancialInstrumentCategory entity)
    {
        return await Task.Run(() =>
        {
            _dbContext.FinancialInstrumentCategories.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        });
    }

    public async Task<FinancialInstrumentCategory> GetById(long id)
    {
        return await _dbContext.FinancialInstrumentCategories.FindAsync(id);
    }

    public async Task<IEnumerable<FinancialInstrumentCategory>> GetByValueRange(double valueRange)
    {
        return await Get(i => i.MinimumMarketValue <= valueRange && i.MaximumMarketValue >= valueRange);
    }

    public async Task<IEnumerable<FinancialInstrumentCategory>> Get(Expression<Func<FinancialInstrumentCategory, bool>> action)
    {
        return await Task.Run(() => _dbContext.FinancialInstrumentCategories.Where(action).ToList());
    }

    public async Task<bool> Insert(FinancialInstrumentCategory entity)
    {
        _dbContext.FinancialInstrumentCategories.Add(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(FinancialInstrumentCategory entity)
    {
        _dbContext.FinancialInstrumentCategories.Update(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}