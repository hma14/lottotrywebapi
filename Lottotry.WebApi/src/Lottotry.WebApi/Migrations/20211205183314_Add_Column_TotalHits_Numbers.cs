using Microsoft.EntityFrameworkCore.Migrations;

namespace Lottotry.WebApi.Migrations
{
    public partial class Add_Column_TotalHits_Numbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHits",
                table: "LottoTypes");

            migrationBuilder.AddColumn<int>(
                name: "TotalHits",
                table: "Numbers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHits",
                table: "Numbers");

            migrationBuilder.AddColumn<int>(
                name: "TotalHits",
                table: "LottoTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
