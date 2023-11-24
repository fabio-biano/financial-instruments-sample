-- If FinancialInstrumentType exists in database, drop it
IF type_id('[dbo].[FinancialInstrumentType]') IS NOT NULL
    DROP TYPE [dbo].[FinancialInstrumentType];

-- Creates FinancialInstrumentType
CREATE TYPE [dbo].[FinancialInstrumentType] AS TABLE
(
	[MarketValue] FLOAT NOT NULL,
    [Type] VARCHAR(150) NOT NULL
);