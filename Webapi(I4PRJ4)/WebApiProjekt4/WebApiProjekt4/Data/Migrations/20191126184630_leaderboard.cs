using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProjekt4.Data.Migrations
{
    public partial class leaderboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Best Time",
                table: "LeaderBoards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Best Time",
                table: "LeaderBoards",
                nullable: true);
        }
    }
}
