namespace FinancialInstruments.UnityTests.Business
{
    [TestClass]
    public partial class FinancialInstrumentTests : BaseTest
    {
        [TestClass]
        public partial class Categorize : FinancialInstrumentTests
        {
            [TestMethod]
            public void GivenNullListReturnsWithNoChanges()
            {   // Arrange
                List<IFinancialInstrument> instrumentCategories = null;

                // Act
                financialInstrumentService.Categorize(instrumentCategories);

                // Assert
                Assert.AreEqual(null, instrumentCategories);
            }

            [TestMethod]
            public void GivenEmptyListReturnsWithNoChages()
            {   // Arrange
                List<IFinancialInstrument> instrumentCategories = new();

                // Act
                financialInstrumentService.Categorize(instrumentCategories);

                // Assert
                Assert.AreEqual(0, instrumentCategories.Count);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void GivenNullElementsMustThrowException()
            {   // Arrange
                List<IFinancialInstrument> instrumentCategories = new() { null };

                // Act
                financialInstrumentService.Categorize(instrumentCategories);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void GivenInvalidMarketValueElementsMustThrowExcpetion()
            {   // Arrange
                List<IFinancialInstrument> instrumentCategories = new() {
                    new Domain.Models.FinancialInstrument(0, "Dummy Test")
                };

                // Act
                financialInstrumentService.Categorize(instrumentCategories);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void GivenNullTypeElementsMustThrowException()
            {   // Arrange
                List<IFinancialInstrument> instrumentCategories = new() {
                    new Domain.Models.FinancialInstrument(150000, null)
                };

                // Act
                financialInstrumentService.Categorize(instrumentCategories);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void GivenEmptyTypeElementsMustThrowException()
            {   // Arrange
                List<IFinancialInstrument> instrumentCategories = new() {
                    new Domain.Models.FinancialInstrument(150000, string.Empty)
                };

                // Act
                financialInstrumentService.Categorize(instrumentCategories);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void GivenWhiteSpaceTypeElementsMustThrowException()
            {   // Arrange
                List<IFinancialInstrument> instrumentCategories = new() {
                    new Domain.Models.FinancialInstrument(150000, " ")
                };

                // Act
                financialInstrumentService.Categorize(instrumentCategories);
            }

            [TestMethod]
            public void GivenValidListOfElementsMustCategorizeList()
            {   // Arrange
                List<IFinancialInstrument> instrumentCategories = GenerateTestList();

                // Act
                financialInstrumentService.Categorize(instrumentCategories);

                // Assert
                Assert.AreEqual(4, instrumentCategories.Count);
                Assert.AreEqual("Low Value", instrumentCategories[0].Category);
                Assert.AreEqual("Medium Value", instrumentCategories[1].Category);
                Assert.AreEqual("High Value", instrumentCategories[2].Category);
                Assert.AreEqual("Low Value", instrumentCategories[3].Category);
            }

            private List<IFinancialInstrument> GenerateTestList()
            {
                return new List<IFinancialInstrument>()  {
                    new Domain.Models.FinancialInstrument(800000, "Stock"),
                    new Domain.Models.FinancialInstrument(1500000, "Bond"),
                    new Domain.Models.FinancialInstrument(6000000, "Derivative"),
                    new Domain.Models.FinancialInstrument(300000, "Stock")
                };
            }
        }
    }
}