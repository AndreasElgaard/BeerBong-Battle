using Microsoft.EntityFrameworkCore.Migrations;

namespace projekt4.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bruger_Register_registerId",
                table: "Bruger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bruger",
                table: "Bruger");

            migrationBuilder.DropIndex(
                name: "IX_Bruger_registerId",
                table: "Bruger");

            migrationBuilder.DropColumn(
                name: "registerId",
                table: "Bruger");

            migrationBuilder.RenameTable(
                name: "Bruger",
                newName: "Brguers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brguers",
                table: "Brguers",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Brguers",
                table: "Brguers");

            migrationBuilder.RenameTable(
                name: "Brguers",
                newName: "Bruger");

            migrationBuilder.AddColumn<int>(
                name: "registerId",
                table: "Bruger",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bruger",
                table: "Bruger",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Bruger_registerId",
                table: "Bruger",
                column: "registerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bruger_Register_registerId",
                table: "Bruger",
                column: "registerId",
                principalTable: "Register",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
