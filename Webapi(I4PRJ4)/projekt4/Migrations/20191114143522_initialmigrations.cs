using Microsoft.EntityFrameworkCore.Migrations;

namespace projekt4.Migrations
{
    public partial class initialmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brguers_Games_Game id",
                table: "Brguers");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Brguers_BrugerId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Brguers_Game id",
                table: "Brguers");

            migrationBuilder.DropColumn(
                name: "Game id",
                table: "Brguers");

            migrationBuilder.AlterColumn<int>(
                name: "BrugerId",
                table: "Participants",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Brguers_BrugerId",
                table: "Participants",
                column: "BrugerId",
                principalTable: "Brguers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brguers_Games_GameId",
                table: "Brguers");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Brguers_BrugerId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Brguers_GameId",
                table: "Brguers");

            migrationBuilder.AlterColumn<int>(
                name: "BrugerId",
                table: "Participants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Game id",
                table: "Brguers",
                type: "int",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Brguers_BrugerId",
                table: "Participants",
                column: "BrugerId",
                principalTable: "Brguers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
