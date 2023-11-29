#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

using System.Reflection;

namespace FinancialInstruments.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialInstrumentCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumMarketValue = table.Column<double>(type: "float", nullable: false),
                    MaximumMarketValue = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialInstrumentCategory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FinancialInstrumentCategory",
                columns: new[] { "Id", "Category", "CreatedAt", "MaximumMarketValue", "MinimumMarketValue", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "Low Value", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000000.0, 0.00, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Medium Value", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000000.0, 1000000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "High Value", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.7976931348623157E+308, 5000000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX1_FINANCIAL_INSTRUMENT_CATEGORY",
                table: "FinancialInstrumentCategory",
                columns: new[] { "MinimumMarketValue", "MaximumMarketValue" },
                unique: true);

            // Add Sql User Types and Stored Procedure
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames().Where(str => str.EndsWith(".sql"));

            foreach (string resourceName in resourceNames)
            {
                using Stream stream = assembly.GetManifestResourceStream(resourceName);
                using StreamReader reader = new StreamReader(stream);
                string sql = reader.ReadToEnd();
                migrationBuilder.Sql(sql);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialInstrumentCategory");
        }
    }
}
