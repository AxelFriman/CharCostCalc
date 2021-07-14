using Microsoft.EntityFrameworkCore.Migrations;

namespace CharCostCalc.Migrations
{
    public partial class bookTierIsNowId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpBooks",
                table: "ExpBooks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExpBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpBooks",
                table: "ExpBooks",
                column: "Tier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpBooks",
                table: "ExpBooks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExpBooks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpBooks",
                table: "ExpBooks",
                column: "Id");
        }
    }
}
