using Microsoft.EntityFrameworkCore.Migrations;

namespace projekt4.Migrations
{
    public partial class foreignkeynullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brguers_Games_GameId",
                table: "Brguers");

            migrationBuilder.DropForeignKey(
                name: "FK_Brguers_LeaderBoards_LeaderBoardId",
                table: "Brguers");

            migrationBuilder.DropForeignKey(
                name: "FK_Brguers_Queues_QueueId",
                table: "Brguers");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Brguers_BrugerId",
                table: "Participants");

            migrationBuilder.AlterColumn<int>(
                name: "BrugerId",
                table: "Participants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QueueId",
                table: "Brguers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LeaderBoardId",
                table: "Brguers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Brguers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Brguers_Games_GameId",
                table: "Brguers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brguers_LeaderBoards_LeaderBoardId",
                table: "Brguers",
                column: "LeaderBoardId",
                principalTable: "LeaderBoards",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brguers_Queues_QueueId",
                table: "Brguers",
                column: "QueueId",
                principalTable: "Queues",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brguers_Games_GameId",
                table: "Brguers");

            migrationBuilder.DropForeignKey(
                name: "FK_Brguers_LeaderBoards_LeaderBoardId",
                table: "Brguers");

            migrationBuilder.DropForeignKey(
                name: "FK_Brguers_Queues_QueueId",
                table: "Brguers");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Brguers_BrugerId",
                table: "Participants");

            migrationBuilder.AlterColumn<int>(
                name: "BrugerId",
                table: "Participants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QueueId",
                table: "Brguers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LeaderBoardId",
                table: "Brguers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Brguers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Brguers_Games_GameId",
                table: "Brguers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Brguers_LeaderBoards_LeaderBoardId",
                table: "Brguers",
                column: "LeaderBoardId",
                principalTable: "LeaderBoards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Brguers_Queues_QueueId",
                table: "Brguers",
                column: "QueueId",
                principalTable: "Queues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Brguers_BrugerId",
                table: "Participants",
                column: "BrugerId",
                principalTable: "Brguers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
