using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onyxshop.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_products_productId",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_productId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "categories");

            migrationBuilder.AddColumn<int>(
                name: "sabaditemid",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "categoryToProducts",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryToProducts", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_categoryToProducts_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoryToProducts_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sabadItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantityinstock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sabadItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_sabaditemid",
                table: "products",
                column: "sabaditemid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categoryToProducts_ProductId",
                table: "categoryToProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_sabadItems_sabaditemid",
                table: "products",
                column: "sabaditemid",
                principalTable: "sabadItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_sabadItems_sabaditemid",
                table: "products");

            migrationBuilder.DropTable(
                name: "categoryToProducts");

            migrationBuilder.DropTable(
                name: "sabadItems");

            migrationBuilder.DropIndex(
                name: "IX_products_sabaditemid",
                table: "products");

            migrationBuilder.DropColumn(
                name: "sabaditemid",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_productId",
                table: "categories",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_products_productId",
                table: "categories",
                column: "productId",
                principalTable: "products",
                principalColumn: "Id");
        }
    }
}
