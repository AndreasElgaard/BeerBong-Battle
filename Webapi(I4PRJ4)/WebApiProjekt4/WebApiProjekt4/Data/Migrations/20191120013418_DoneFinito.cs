using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProjekt4.Data.Migrations
{
    public partial class DoneFinito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Start_QueueTime",
                table: "Queues");

            migrationBuilder.DropColumn(
                name: "Result from drinking bear",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Start_QueueTime",
                table: "Queues",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "Result from drinking bear",
                table: "Games",
                nullable: true);
        }
    }
}
