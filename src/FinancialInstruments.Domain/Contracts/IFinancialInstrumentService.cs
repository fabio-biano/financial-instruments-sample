namespace FinancialInstruments.Domain.Contracts
{
    public interface IFinancialInstrumentService
    {
        void Categorize(List<IFinancialInstrument> financialInstruments);
    }
}