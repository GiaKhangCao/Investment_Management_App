using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMA.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionToInvestment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Portfolios_porfolioId",
                table: "Investments");

            migrationBuilder.RenameColumn(
                name: "porfolioId",
                table: "Investments",
                newName: "portfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_porfolioId",
                table: "Investments",
                newName: "IX_Investments_portfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Portfolios_portfolioId",
                table: "Investments",
                column: "portfolioId",
                principalTable: "Portfolios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_Portfolios_portfolioId",
                table: "Investments");

            migrationBuilder.RenameColumn(
                name: "portfolioId",
                table: "Investments",
                newName: "porfolioId");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_portfolioId",
                table: "Investments",
                newName: "IX_Investments_porfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_Portfolios_porfolioId",
                table: "Investments",
                column: "porfolioId",
                principalTable: "Portfolios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
