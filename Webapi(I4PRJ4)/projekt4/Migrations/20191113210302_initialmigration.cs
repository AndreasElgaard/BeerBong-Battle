using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projekt4.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resultfromdrinkingbear = table.Column<string>(name: "Result from drinking bear", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LeaderBoards",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BestTime = table.Column<string>(name: "Best Time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderBoards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Queues",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_created = table.Column<byte[]>(type: "Timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queues", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Brguers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    GameId = table.Column<int>(nullable: false),
                    QueueId = table.Column<int>(nullable: false),
                    LeaderBoardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brguers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Brguers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Brguers_LeaderBoards_LeaderBoardId",
                        column: x => x.LeaderBoardId,
                        principalTable: "LeaderBoards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Brguers_Queues_QueueId",
                        column: x => x.QueueId,
                        principalTable: "Queues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Participant_name = table.Column<string>(maxLength: 50, nullable: true),
                    Result_from_drinking = table.Column<double>(nullable: false),
                    BrugerId = table.Column<int>(nullable: false),
                    QueueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.id);
                    table.ForeignKey(
                        name: "FK_Participants_Brguers_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Brguers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_Queues_QueueId",
                        column: x => x.QueueId,
                        principalTable: "Queues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brguers_GameId",
                table: "Brguers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Brguers_LeaderBoardId",
                table: "Brguers",
                column: "LeaderBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Brguers_QueueId",
                table: "Brguers",
                column: "QueueId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_BrugerId",
                table: "Participants",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_QueueId",
                table: "Participants",
                column: "QueueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Brguers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "LeaderBoards");

            migrationBuilder.DropTable(
                name: "Queues");
        }
    }
}
