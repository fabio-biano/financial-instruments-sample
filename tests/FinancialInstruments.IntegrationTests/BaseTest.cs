namespace FinancialInstruments.IntegrationTests
{
    public class BaseTest
    {
        protected readonly FinancialInstrumentsContext context;

        public BaseTest()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

            var options = new DbContextOptionsBuilder<FinancialInstrumentsContext>()
                .UseSqlServer(configuration.GetConnectionString("FinancialInstruments.DbContext"))
                .Options;
            var databaseContext = new FinancialInstrumentsContext(options);
            databaseContext.Database.EnsureCreated();

            context = new FinancialInstrumentsContext(options);
        }

        protected DataTable GetTestFinantialInstrumentTable()
        {
            DataTable table = new();
            table.Columns.Add("MarketValue", typeof(double));
            table.Columns.Add("Type", typeof(string));            
            return table;
        }
    }
}