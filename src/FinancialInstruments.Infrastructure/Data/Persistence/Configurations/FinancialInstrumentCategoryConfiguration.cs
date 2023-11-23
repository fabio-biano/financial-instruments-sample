namespace FinancialInstruments.Infrastructure.Data.Persistence.Configurations;

public class FinancialInstrumentCategoryConfiguration : IEntityTypeConfiguration<FinancialInstrumentCategory>
{
    public void Configure(EntityTypeBuilder<FinancialInstrumentCategory> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .UseIdentityColumn();
            
        builder.Property(p => p.MinimumMarketValue)
            .IsRequired();
            
        builder.Property(p => p.MaximumMarketValue)
            .IsRequired();

        builder.Property(p => p.Category)
            .HasMaxLength(150)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .IsRequired();
    }
}