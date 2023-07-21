using Microsoft.EntityFrameworkCore.Migrations;

namespace FudbalskiTurnir.Migrations
{
    public partial class UpdateResultTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Results",
                newName: "MatchResult");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatchResult",
                table: "Results",
                newName: "Result");
        }
    }
}
