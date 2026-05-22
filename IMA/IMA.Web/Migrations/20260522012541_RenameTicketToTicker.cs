using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMA.Web.Migrations
{
    /// <inheritdoc />
    public partial class RenameTicketToTicker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ticket",
                table: "Investments",
                newName: "ticker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ticker",
                table: "Investments",
                newName: "ticket");
        }
    }
}
