CREATE OR ALTER PROCEDURE USP_CATEGORIZE_FINANCIAL_INSTRUMENTS @FINANCIAL_INSTRUMENTS FinancialInstrumentType READONLY
AS
	SELECT
		FI.[Type],
		FI.[MarketValue],
		CAT.Category,
		CAT.Id,
		CAT.MinimumMarketValue,
		CAT.MaximumMarketValue,
		CAT.CreatedAt,
		CAT.UpdatedAt
	FROM @FINANCIAL_INSTRUMENTS FI
	CROSS APPLY (
		SELECT TOP 1 [Id], [Category], [MinimumMarketValue], [MaximumMarketValue], [CreatedAt], [UpdatedAt]
		FROM [FinancialInstrumentCategory]
		WHERE [MinimumMarketValue] <= FI.[MarketValue]
		  AND MaximumMarketValue >= FI.[MarketValue]
	) AS CAT