using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProjekt4.Data.Migrations
{
    public partial class Done : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_LeaderBoards_LeaderBoardId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Queues_QueueId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Players_PlayerId",
                table: "Stats");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_LeaderBoards_LeaderBoardId",
                table: "Players",
                column: "LeaderBoardId",
                principalTable: "LeaderBoards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Queues_QueueId",
                table: "Players",
                column: "QueueId",
                principalTable: "Queues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Players_PlayerId",
                table: "Stats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_LeaderBoards_LeaderBoardId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Queues_QueueId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Players_PlayerId",
                table: "Stats");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_LeaderBoards_LeaderBoardId",
                table: "Players",
                column: "LeaderBoardId",
                principalTable: "LeaderBoards",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Queues_QueueId",
                table: "Players",
                column: "QueueId",
                principalTable: "Queues",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Players_PlayerId",
                table: "Stats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
