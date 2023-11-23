namespace FinancialInstruments.Infrastructure.Data.Repositories;

public class FinancialInsrumentCategoryRepository : IFinancialInstrumentCategoryRepository, IDisposable
{
    private readonly IDbContext _dbContext;

    public FinancialInsrumentCategoryRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Delete(FinancialInstrumentCategory entity)
    {
        _dbContext.FinancialInstrumentCategories.Remove(entity);
        return _dbContext.SaveChanges() > 0;
    }

    public FinancialInstrumentCategory GetById(long id)
    {
        return _dbContext.FinancialInstrumentCategories.Find(id);
    }

    public IEnumerable<FinancialInstrumentCategory> GetByValueRange(double valueRange)
    {
        return Get(i => i.MinimumMarketValue <= valueRange && i.MaximumMarketValue >= valueRange);
    }

    public IEnumerable<FinancialInstrumentCategory> Get(Expression<Func<FinancialInstrumentCategory, bool>> action)
    {
        return _dbContext.FinancialInstrumentCategories.Where(action).ToList();
    }

    public bool Insert(FinancialInstrumentCategory entity)
    {
        _dbContext.FinancialInstrumentCategories.Add(entity);
        return _dbContext.SaveChanges() > 0;
    }

    public bool Update(FinancialInstrumentCategory entity)
    {
        _dbContext.FinancialInstrumentCategories.Update(entity);
        return _dbContext.SaveChanges() > 0;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}