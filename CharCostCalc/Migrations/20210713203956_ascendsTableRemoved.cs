using Microsoft.EntityFrameworkCore.Migrations;

namespace CharCostCalc.Migrations
{
    public partial class ascendsTableRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Upgrades_Ascends_AscId",
                table: "Upgrades");

            migrationBuilder.DropTable(
                name: "Ascends");

            migrationBuilder.DropIndex(
                name: "IX_Upgrades_AscId",
                table: "Upgrades");

            migrationBuilder.DropColumn(
                name: "AscId",
                table: "Upgrades");

            migrationBuilder.AddColumn<int>(
                name: "Lvl",
                table: "Upgrades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lvl",
                table: "Upgrades");

            migrationBuilder.AddColumn<int>(
                name: "AscId",
                table: "Upgrades",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ascends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lvl = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ascends", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Upgrades_AscId",
                table: "Upgrades",
                column: "AscId");

            migrationBuilder.AddForeignKey(
                name: "FK_Upgrades_Ascends_AscId",
                table: "Upgrades",
                column: "AscId",
                principalTable: "Ascends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
