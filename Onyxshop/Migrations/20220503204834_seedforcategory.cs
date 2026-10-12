using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onyxshop.Migrations
{
    public partial class seedforcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name", "decription", "productId" },
                values: new object[,]
                {
                    { 1, "گردنبند ", "گردنبند های طلا و نقره در مدل ها و سبک های مختلف ", null },
                    { 2, "النگو ", "النگو های طلا و نقره در مدل ها و سبک های مختلف ", null },
                    { 3, "دستبند ", "دستبند های طلا و نقره در مدل ها و سبک های مختلف ", null },
                    { 4, "انگشتر", "انگشتر های طلا و نقره در مدل ها و سبک های مختلف ", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
