using Microsoft.EntityFrameworkCore.Migrations;

namespace FudbalskiTurnir.Migrations
{
    public partial class AddResultColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Team1Result",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Team2Result",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team1Result",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Team2Result",
                table: "Results");
        }
    }
}
