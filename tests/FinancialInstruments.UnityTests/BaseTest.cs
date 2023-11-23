namespace FinancialInstruments.UnityTests
{
    public class BaseTest
    {
        protected readonly IDbContext mockDbContext;
        protected readonly IFinancialInstrumentService financialInstrumentService;

        public BaseTest()
        {
            var mockSet = new Mock<DbSet<FinancialInstrumentCategory>>();
            var mockContext = new Mock<IDbContext>();
            mockContext.Setup(m => m.FinancialInstrumentCategories).Returns(mockSet.Object);

            mockDbContext = mockContext.Object;

            var mockRepo = new Mock<IFinancialInstrumentCategoryRepository>();
            mockRepo.Setup(e => e.GetByValueRange(800000)).Returns(new List<FinancialInstrumentCategory>()
                { new FinancialInstrumentCategory() { Id = 1, MinimumMarketValue = 0.01, MaximumMarketValue = 999999.99, Category = "Low Value", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            });
            mockRepo.Setup(e => e.GetByValueRange(1500000)).Returns(new List<FinancialInstrumentCategory>()
                { new FinancialInstrumentCategory() { Id = 2, MinimumMarketValue = 1000000.00, MaximumMarketValue = 5000000.00, Category = "Medium Value", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            });
            mockRepo.Setup(e => e.GetByValueRange(6000000)).Returns(new List<FinancialInstrumentCategory>()
                { new FinancialInstrumentCategory() { Id = 3, MinimumMarketValue = 5000000.01, MaximumMarketValue = double.MaxValue, Category = "High Value", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            });
            mockRepo.Setup(e => e.GetByValueRange(300000)).Returns(new List<FinancialInstrumentCategory>()
                { new FinancialInstrumentCategory() { Id = 1, MinimumMarketValue = 0.01, MaximumMarketValue = 999999.99, Category = "Low Value", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            });
            IFinancialInstrumentCategoryRepository repo = mockRepo.Object;

            financialInstrumentService = new FinancialInstrumentService(repo);
        }
    }
}