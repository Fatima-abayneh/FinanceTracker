using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class amountstatuss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Budgets",
                newName: "InicialAmount");

            migrationBuilder.AddColumn<double>(
                name: "CurrentAmount",
                table: "Budgets",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentAmount",
                table: "Budgets");

            migrationBuilder.RenameColumn(
                name: "InicialAmount",
                table: "Budgets",
                newName: "amount");
        }
    }
}
