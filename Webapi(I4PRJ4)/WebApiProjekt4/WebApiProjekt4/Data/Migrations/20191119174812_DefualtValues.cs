using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProjekt4.Data.Migrations
{
    public partial class DefualtValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_created",
                table: "Queues");

            migrationBuilder.AddColumn<DateTime>(
                name: "Start_QueueTime",
                table: "Queues",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Start_QueueTime",
                table: "Queues");

            migrationBuilder.AddColumn<byte[]>(
                name: "date_created",
                table: "Queues",
                type: "Timestamp",
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
