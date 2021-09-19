using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lottotry.WebApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BC49",
                columns: table => new
                {
                    DrawNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number1 = table.Column<int>(type: "int", nullable: false),
                    Number2 = table.Column<int>(type: "int", nullable: false),
                    Number3 = table.Column<int>(type: "int", nullable: false),
                    Number4 = table.Column<int>(type: "int", nullable: false),
                    Number5 = table.Column<int>(type: "int", nullable: false),
                    Number6 = table.Column<int>(type: "int", nullable: false),
                    Bonus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BC49", x => x.DrawNumber);
                });

            migrationBuilder.CreateTable(
                name: "Lotto649",
                columns: table => new
                {
                    DrawNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number1 = table.Column<int>(type: "int", nullable: false),
                    Number2 = table.Column<int>(type: "int", nullable: false),
                    Number3 = table.Column<int>(type: "int", nullable: false),
                    Number4 = table.Column<int>(type: "int", nullable: false),
                    Number5 = table.Column<int>(type: "int", nullable: false),
                    Number6 = table.Column<int>(type: "int", nullable: false),
                    Bonus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotto649", x => x.DrawNumber);
                });

            migrationBuilder.CreateTable(
                name: "LottoMax",
                columns: table => new
                {
                    DrawNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number1 = table.Column<int>(type: "int", nullable: false),
                    Number2 = table.Column<int>(type: "int", nullable: false),
                    Number3 = table.Column<int>(type: "int", nullable: false),
                    Number4 = table.Column<int>(type: "int", nullable: false),
                    Number5 = table.Column<int>(type: "int", nullable: false),
                    Number6 = table.Column<int>(type: "int", nullable: false),
                    Number7 = table.Column<int>(type: "int", nullable: false),
                    Bonus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LottoMax", x => x.DrawNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BC49");

            migrationBuilder.DropTable(
                name: "Lotto649");

            migrationBuilder.DropTable(
                name: "LottoMax");
        }
    }
}
