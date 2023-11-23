namespace FinancialInstruments.Infrastructure.Data.Entities;

public abstract class BaseEntity : IEntity
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}