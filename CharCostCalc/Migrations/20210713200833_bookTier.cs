using Microsoft.EntityFrameworkCore.Migrations;

namespace CharCostCalc.Migrations
{
    public partial class bookTier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExpBooks");

            migrationBuilder.AddColumn<int>(
                name: "Tier",
                table: "ExpBooks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tier",
                table: "ExpBooks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExpBooks",
                type: "TEXT",
                nullable: true);
        }
    }
}
