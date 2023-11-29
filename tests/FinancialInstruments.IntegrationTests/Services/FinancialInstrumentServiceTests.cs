using FinancialInstruments.Domain.Models;
using FinancialInstruments.Domain.Services;
using FinancialInstruments.Infrastructure.Contracts;
using FinancialInstruments.Infrastructure.Data.Repositories;

namespace FinancialInstruments.IntegrationTests.Services
{
    [TestClass]
    public class FinancialInstrumentServiceTests : BaseTest
    {
        private IFinancialInstrumentService service;

        public FinancialInstrumentServiceTests()
        {
            IFinancialInstrumentCategoryRepository repo = new FinancialInsrumentCategoryRepository(context);
            service = new FinancialInstrumentService(repo);
        }

        [TestMethod]
        public void GivenValidValuesMustCategorizeList()
        {   // Arrange
            List<IFinancialInstrument> instruments = new()
            {
                new FinancialInstrument(800000, "Stock"),
                new FinancialInstrument(1500000, "Bond"),
                new FinancialInstrument(6000000, "Derivative"),
                new FinancialInstrument(300000, "Stock")
            };

            // Act
            service.Categorize(instruments);

            // Assert
            Assert.AreEqual(4, instruments.Count);
            Assert.AreEqual("Low Value", instruments[0].Category);
            Assert.AreEqual("Medium Value", instruments[1].Category);
            Assert.AreEqual("High Value", instruments[2].Category);
            Assert.AreEqual("Low Value", instruments[3].Category);
        }
    }
}