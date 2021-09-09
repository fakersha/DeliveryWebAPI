using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryWebAPI.Domain.Migrations
{
    public partial class changedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_categoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_productsWithIngredients_Ingredients_ingredientId",
                table: "productsWithIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_productsWithIngredients_Products_productid",
                table: "productsWithIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productsWithIngredients",
                table: "productsWithIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "productsWithIngredients",
                newName: "ProductsWithIngredients");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_productsWithIngredients_productid",
                table: "ProductsWithIngredients",
                newName: "IX_ProductsWithIngredients_productid");

            migrationBuilder.RenameIndex(
                name: "IX_productsWithIngredients_ingredientId",
                table: "ProductsWithIngredients",
                newName: "IX_ProductsWithIngredients_ingredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsWithIngredients",
                table: "ProductsWithIngredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryId",
                table: "Products",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsWithIngredients_Ingredients_ingredientId",
                table: "ProductsWithIngredients",
                column: "ingredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsWithIngredients_Products_productid",
                table: "ProductsWithIngredients",
                column: "productid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsWithIngredients_Ingredients_ingredientId",
                table: "ProductsWithIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsWithIngredients_Products_productid",
                table: "ProductsWithIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsWithIngredients",
                table: "ProductsWithIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "ProductsWithIngredients",
                newName: "productsWithIngredients");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "ProductCategories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsWithIngredients_productid",
                table: "productsWithIngredients",
                newName: "IX_productsWithIngredients_productid");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsWithIngredients_ingredientId",
                table: "productsWithIngredients",
                newName: "IX_productsWithIngredients_ingredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productsWithIngredients",
                table: "productsWithIngredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_categoryId",
                table: "Products",
                column: "categoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productsWithIngredients_Ingredients_ingredientId",
                table: "productsWithIngredients",
                column: "ingredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productsWithIngredients_Products_productid",
                table: "productsWithIngredients",
                column: "productid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
