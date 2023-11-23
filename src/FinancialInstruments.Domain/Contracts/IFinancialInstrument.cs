namespace FinancialInstruments.Domain.Contracts
{
    public interface IFinancialInstrument
    {
        double MarketValue { get; }
        string Type { get; }
        string? Category { get; set; }
    }
}