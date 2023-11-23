namespace FinancialInstruments.Domain.Services
{
    public class FinancialInstrumentService : IFinancialInstrumentService, IDisposable
    {
        protected readonly IFinancialInstrumentCategoryRepository repository;

        public FinancialInstrumentService(IFinancialInstrumentCategoryRepository repo)
        {
            repository = repo;
        }

        public void Categorize(List<IFinancialInstrument> financialInstruments)
        {
            if (financialInstruments is null || financialInstruments.Count == 0)
                return;

            if (financialInstruments.Any(i => i is null))
                throw new ArgumentException("Invalid argument. The 'financialInstruments list contains null objects.");

            Parallel.ForEach(financialInstruments, i =>
            {
                var category = repository.GetByValueRange(i.MarketValue).FirstOrDefault();
                i.Category = (category is null || string.IsNullOrWhiteSpace(category.Category)) ? "Unknown" : category.Category;
            });
        }

        public void Dispose()
        {
            repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}