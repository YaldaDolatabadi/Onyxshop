using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onyxshop.Migrations
{
    public partial class uu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "count",
                table: "orderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                table: "orderDetails");
        }
    }
}
