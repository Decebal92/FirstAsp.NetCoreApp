using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcFootballTeams.Migrations
{
    public partial class Value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "FootballTeam",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "FootballTeam");
        }
    }
}
