namespace FinancialInstruments.Infrastructure.Contracts;

public interface IFinancialInstrumentCategoryRepository : IDisposable
{
    Task<FinancialInstrumentCategory> GetById(long id);
    Task<IEnumerable<FinancialInstrumentCategory>> GetByValueRange(double valueRange);
    Task<IEnumerable<FinancialInstrumentCategory>> Get(Expression<Func<FinancialInstrumentCategory, bool>> action);
    Task<bool> Update(FinancialInstrumentCategory entity);
    Task<bool> Insert(FinancialInstrumentCategory entity);
    Task<bool> Delete(FinancialInstrumentCategory entity);
}