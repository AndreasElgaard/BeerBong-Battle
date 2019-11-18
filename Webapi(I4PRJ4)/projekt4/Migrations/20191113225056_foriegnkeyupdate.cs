using Microsoft.EntityFrameworkCore.Migrations;

namespace projekt4.Migrations
{
    public partial class foriegnkeyupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brguers_Games_GameId",
                table: "Brguers");

            migrationBuilder.DropIndex(
                name: "IX_Brguers_GameId",
                table: "Brguers");

            migrationBuilder.AddColumn<int>(
                name: "Game id",
                table: "Brguers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brguers_Game id",
                table: "Brguers",
                column: "Game id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brguers_Games_Game id",
                table: "Brguers",
                column: "Game id",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brguers_Games_Game id",
                table: "Brguers");

            migrationBuilder.DropIndex(
                name: "IX_Brguers_Game id",
                table: "Brguers");

            migrationBuilder.DropColumn(
                name: "Game id",
                table: "Brguers");

            migrationBuilder.CreateIndex(
                name: "IX_Brguers_GameId",
                table: "Brguers",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brguers_Games_GameId",
                table: "Brguers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
