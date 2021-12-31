using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lottotry.WebApi.Migrations
{
    public partial class Add_Table_DailyGrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyGrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrawNumber = table.Column<int>(type: "int", nullable: false),
                    DrawDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number1 = table.Column<int>(type: "int", nullable: false),
                    Number2 = table.Column<int>(type: "int", nullable: false),
                    Number3 = table.Column<int>(type: "int", nullable: false),
                    Number4 = table.Column<int>(type: "int", nullable: false),
                    Number5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyGrand", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyGrand");
        }
    }
}
