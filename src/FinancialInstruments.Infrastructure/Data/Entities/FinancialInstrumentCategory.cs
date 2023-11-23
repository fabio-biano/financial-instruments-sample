namespace FinancialInstruments.Infrastructure.Data.Entities
{
    [Table("FinancialInstrumentCategory"), Index(nameof(MinimumMarketValue), nameof(MaximumMarketValue), IsUnique = true, Name = "IX1_FINANCIAL_INSTRUMENT_CATEGORY")]
    public class FinancialInstrumentCategory : BaseEntity
    {
        public double MinimumMarketValue { get; set; }

        public double MaximumMarketValue { get; set; }

        public string Category { get; set; }
    }
}