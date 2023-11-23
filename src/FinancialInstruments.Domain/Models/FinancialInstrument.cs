namespace FinancialInstruments.Domain.Models
{
    public class FinancialInstrument : IFinancialInstrument
    {
        public double MarketValue { get; }

        public string Type { get; }

        public string? Category { get; set; }

        public FinancialInstrument(double marketValue, string type)
        {
            if (marketValue <= 0)
                throw new ArgumentException("Invalid market value. The 'marketValue' must be a positive number.");

            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Invalid type. The 'type' cannot be null, an empty string or a white space.");

            MarketValue = marketValue;
            Type = type;
        }
    }
}