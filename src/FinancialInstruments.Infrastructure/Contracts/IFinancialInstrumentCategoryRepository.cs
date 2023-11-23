namespace FinancialInstruments.Infrastructure.Contracts;

public interface IFinancialInstrumentCategoryRepository : IDisposable
{
    FinancialInstrumentCategory GetById(long id);
    IEnumerable<FinancialInstrumentCategory> GetByValueRange(double valueRange);
    IEnumerable<FinancialInstrumentCategory> Get(Expression<Func<FinancialInstrumentCategory, bool>> action);
    bool Update(FinancialInstrumentCategory entity);
    bool Insert(FinancialInstrumentCategory entity);
    bool Delete(FinancialInstrumentCategory entity);
}