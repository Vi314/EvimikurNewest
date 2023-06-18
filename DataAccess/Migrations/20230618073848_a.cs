using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Dealers_DealerModelId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_ProductModelId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "DealerModelProductPriceModel");

            migrationBuilder.DropIndex(
                name: "IX_Sales_DealerModelId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ProductModelId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "DealerModelId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                table: "Sales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DealerModelId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductModelId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DealerModelProductPriceModel",
                columns: table => new
                {
                    DealersId = table.Column<int>(type: "int", nullable: false),
                    ProductPricesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerModelProductPriceModel", x => new { x.DealersId, x.ProductPricesId });
                    table.ForeignKey(
                        name: "FK_DealerModelProductPriceModel_Dealers_DealersId",
                        column: x => x.DealersId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DealerModelProductPriceModel_ProductPrices_ProductPricesId",
                        column: x => x.ProductPricesId,
                        principalTable: "ProductPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DealerModelId",
                table: "Sales",
                column: "DealerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductModelId",
                table: "Sales",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerModelProductPriceModel_ProductPricesId",
                table: "DealerModelProductPriceModel",
                column: "ProductPricesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Dealers_DealerModelId",
                table: "Sales",
                column: "DealerModelId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductModelId",
                table: "Sales",
                column: "ProductModelId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
