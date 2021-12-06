using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lottotry.WebApi.Migrations
{
    public partial class Add_Tables_LottoTypes_Numbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LottoTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LottoName = table.Column<int>(type: "int", nullable: false),
                    DrawNumber = table.Column<int>(type: "int", nullable: false),
                    DrawDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberRange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LottoTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Numbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    LottoTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    IsHit = table.Column<bool>(type: "bit", nullable: false),
                    NumberofDrawsWhenHit = table.Column<int>(type: "int", nullable: false),
                    IsBonusNumber = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Numbers_LottoTypes_LottoTypeId",
                        column: x => x.LottoTypeId,
                        principalTable: "LottoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Numbers_LottoTypeId",
                table: "Numbers",
                column: "LottoTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Numbers");

            migrationBuilder.DropTable(
                name: "LottoTypes");
        }
    }
}
