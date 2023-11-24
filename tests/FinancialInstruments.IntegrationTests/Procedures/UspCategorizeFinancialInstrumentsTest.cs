namespace FinancialInstruments.IntegrationTests.Procedures
{
    [TestClass]
    public class UspCategorizeFinancialInstrumentsTest : BaseTest
    {
        [TestMethod]
        public void GivenValidValuesMustCategorizeList()
        {   // Arrange
            DataTable table = GetTestFinantialInstrumentTable();
            DataRow row = table.NewRow();
            row["Type"] = "Stock";
            row["MarketValue"] = 800000;
            table.Rows.Add(row);

            row = table.NewRow();
            row["Type"] = "Bond";
            row["MarketValue"] = 1500000;
            table.Rows.Add(row);

            row = table.NewRow();
            row["Type"] = "Derivative";
            row["MarketValue"] = 6000000;
            table.Rows.Add(row);

            row = table.NewRow();
            row["Type"] = "Stock";
            row["MarketValue"] = 300000;
            table.Rows.Add(row);

            // Act
            var param = new SqlParameter("FINANCIAL_INSTRUMENTS", table);
            param.TypeName = "dbo.FinancialInstrumentType";
            var result = context.FinancialInstrumentCategories.FromSqlRaw("EXEC USP_CATEGORIZE_FINANCIAL_INSTRUMENTS @FINANCIAL_INSTRUMENTS", param).ToList();

            // Assert
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual("Low Value", result[0].Category);
            Assert.AreEqual("Medium Value", result[1].Category);
            Assert.AreEqual("High Value", result[2].Category);
            Assert.AreEqual("Low Value", result[3].Category);
        }
    }
}