using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projekt4.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brugerid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bruger",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    last_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    date_created = table.Column<DateTime>(type: "date", nullable: true),
                    registerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bruger", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bruger_Register_registerId",
                        column: x => x.registerId,
                        principalTable: "Register",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bruger_registerId",
                table: "Bruger",
                column: "registerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bruger");

            migrationBuilder.DropTable(
                name: "Register");
        }
    }
}
