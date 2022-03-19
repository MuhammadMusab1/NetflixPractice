using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetfilxPractice.Data.Migrations
{
    public partial class SeedSomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Shows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Shows");
        }
    }
}
