CREATE OR ALTER PROCEDURE USP_CATEGORIZE_FINANCIAL_INSTRUMENTS @FINANCIAL_INSTRUMENTS FinancialInstrumentType READONLY
AS
	SELECT
		FI.[Type],
		FI.[MarketValue],
		CAT.Category
	FROM @FINANCIAL_INSTRUMENTS FI
	CROSS APPLY (
		SELECT TOP 1 [Category]
		FROM [FinancialInstrumentCategory]
		WHERE [MinimumMarketValue] <= FI.[MarketValue]
		  AND MaximumMarketValue >= FI.[MarketValue]
	) AS CAT