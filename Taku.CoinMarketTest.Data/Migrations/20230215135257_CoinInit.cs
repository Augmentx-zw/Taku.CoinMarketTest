using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taku.CoinMarketTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class CoinInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptoCoins",
                columns: table => new
                {
                    CryptoCoinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cmc_rank = table.Column<int>(type: "int", nullable: false),
                    Num_market_pairs = table.Column<int>(type: "int", nullable: false),
                    Circulating_supply = table.Column<int>(type: "int", nullable: false),
                    Total_supply = table.Column<int>(type: "int", nullable: false),
                    Max_supply = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessedTags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoinTags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Self_reported_circulating_supply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Self_reported_market_cap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_added = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoCoins", x => x.CryptoCoinId);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Volume_24h = table.Column<int>(type: "int", nullable: false),
                    Volume_change_24h = table.Column<double>(type: "float", nullable: false),
                    Percent_change_1h = table.Column<double>(type: "float", nullable: false),
                    Percent_change_24h = table.Column<double>(type: "float", nullable: false),
                    Percent_change_7d = table.Column<double>(type: "float", nullable: false),
                    Market_cap = table.Column<double>(type: "float", nullable: false),
                    Market_cap_dominance = table.Column<int>(type: "int", nullable: false),
                    Fully_diluted_market_cap = table.Column<double>(type: "float", nullable: false),
                    Last_updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CryptoCoinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Error_code = table.Column<int>(type: "int", nullable: false),
                    Error_message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elapsed = table.Column<int>(type: "int", nullable: false),
                    Credit_count = table.Column<int>(type: "int", nullable: false),
                    Notice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptoCoins");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
