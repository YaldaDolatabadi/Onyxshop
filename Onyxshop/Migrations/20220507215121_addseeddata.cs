using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onyxshop.Migrations
{
    public partial class addseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "sabadItems",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "vazn",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "sabadItems",
                columns: new[] { "Id", "price", "quantityinstock" },
                values: new object[] { 1, 5000000.0m, 1 });

            migrationBuilder.InsertData(
                table: "sabadItems",
                columns: new[] { "Id", "price", "quantityinstock" },
                values: new object[] { 2, 1000000.0m, 1 });

            migrationBuilder.InsertData(
                table: "sabadItems",
                columns: new[] { "Id", "price", "quantityinstock" },
                values: new object[] { 3, 450000.0m, 2 });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Name", "description", "sabaditemid", "vazn" },
                values: new object[] { 1, "زنجیر ساده طلا", "زنجیر ساده طلا باریک 23 سانتیمتری ", 1, 4m });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Name", "description", "sabaditemid", "vazn" },
                values: new object[] { 2, "رینگ ساه زنانه طلا", "رینگ ساده زنانه طلای زرد پهنای متوسط", 2, 4.5m });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Name", "description", "sabaditemid", "vazn" },
                values: new object[] { 3, " A گردنبند", "پلاک زنانه حرف A بهمراه رنجیر", 3, 2.34m });

            migrationBuilder.InsertData(
                table: "categoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "categoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "categoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 4, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "categoryToProducts",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "sabadItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "sabadItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "sabadItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "vazn",
                table: "products");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "sabadItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
