using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedModelForEntityNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealerStocks_Dealers_DealerId",
                table: "DealerStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Dealers_DealerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dealers_DealerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceAndDealers_Dealers_DealerId",
                table: "ProductPriceAndDealers");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesAndDealers_Dealers_DealerId",
                table: "SalesAndDealers");

            migrationBuilder.DropTable(
                name: "DealerProductPrice");

            migrationBuilder.DropTable(
                name: "DealerSale");

            migrationBuilder.DropTable(
                name: "ProductSale");

            migrationBuilder.DropIndex(
                name: "IX_SalesAndDealers_DealerId",
                table: "SalesAndDealers");

            migrationBuilder.DropIndex(
                name: "IX_ProductPriceAndDealers_DealerId",
                table: "ProductPriceAndDealers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DealerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DealerId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_DealerStocks_DealerId",
                table: "DealerStocks");

            migrationBuilder.AddColumn<int>(
                name: "DealerModelId",
                table: "SalesAndDealers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DealerModelId",
                table: "ProductPriceAndDealers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DealerModelId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DealerModelId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DealerModelId",
                table: "DealerStocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "DealerModelSaleModel",
                columns: table => new
                {
                    DealersId = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerModelSaleModel", x => new { x.DealersId, x.SalesId });
                    table.ForeignKey(
                        name: "FK_DealerModelSaleModel_Dealers_DealersId",
                        column: x => x.DealersId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DealerModelSaleModel_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductModelSaleModel",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelSaleModel", x => new { x.ProductsId, x.SalesId });
                    table.ForeignKey(
                        name: "FK_ProductModelSaleModel_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelSaleModel_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesAndDealers_DealerModelId",
                table: "SalesAndDealers",
                column: "DealerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceAndDealers_DealerModelId",
                table: "ProductPriceAndDealers",
                column: "DealerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DealerModelId",
                table: "Orders",
                column: "DealerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DealerModelId",
                table: "Employees",
                column: "DealerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerStocks_DealerModelId",
                table: "DealerStocks",
                column: "DealerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerModelProductPriceModel_ProductPricesId",
                table: "DealerModelProductPriceModel",
                column: "ProductPricesId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerModelSaleModel_SalesId",
                table: "DealerModelSaleModel",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelSaleModel_SalesId",
                table: "ProductModelSaleModel",
                column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerStocks_Dealers_DealerModelId",
                table: "DealerStocks",
                column: "DealerModelId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Dealers_DealerModelId",
                table: "Employees",
                column: "DealerModelId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dealers_DealerModelId",
                table: "Orders",
                column: "DealerModelId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceAndDealers_Dealers_DealerModelId",
                table: "ProductPriceAndDealers",
                column: "DealerModelId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesAndDealers_Dealers_DealerModelId",
                table: "SalesAndDealers",
                column: "DealerModelId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DealerStocks_Dealers_DealerModelId",
                table: "DealerStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Dealers_DealerModelId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dealers_DealerModelId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPriceAndDealers_Dealers_DealerModelId",
                table: "ProductPriceAndDealers");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesAndDealers_Dealers_DealerModelId",
                table: "SalesAndDealers");

            migrationBuilder.DropTable(
                name: "DealerModelProductPriceModel");

            migrationBuilder.DropTable(
                name: "DealerModelSaleModel");

            migrationBuilder.DropTable(
                name: "ProductModelSaleModel");

            migrationBuilder.DropIndex(
                name: "IX_SalesAndDealers_DealerModelId",
                table: "SalesAndDealers");

            migrationBuilder.DropIndex(
                name: "IX_ProductPriceAndDealers_DealerModelId",
                table: "ProductPriceAndDealers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DealerModelId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DealerModelId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_DealerStocks_DealerModelId",
                table: "DealerStocks");

            migrationBuilder.DropColumn(
                name: "DealerModelId",
                table: "SalesAndDealers");

            migrationBuilder.DropColumn(
                name: "DealerModelId",
                table: "ProductPriceAndDealers");

            migrationBuilder.DropColumn(
                name: "DealerModelId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DealerModelId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DealerModelId",
                table: "DealerStocks");

            migrationBuilder.CreateTable(
                name: "DealerProductPrice",
                columns: table => new
                {
                    DealersId = table.Column<int>(type: "int", nullable: false),
                    ProductPricesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerProductPrice", x => new { x.DealersId, x.ProductPricesId });
                    table.ForeignKey(
                        name: "FK_DealerProductPrice_Dealers_DealersId",
                        column: x => x.DealersId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DealerProductPrice_ProductPrices_ProductPricesId",
                        column: x => x.ProductPricesId,
                        principalTable: "ProductPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DealerSale",
                columns: table => new
                {
                    DealersId = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerSale", x => new { x.DealersId, x.SalesId });
                    table.ForeignKey(
                        name: "FK_DealerSale_Dealers_DealersId",
                        column: x => x.DealersId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DealerSale_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSale",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSale", x => new { x.ProductsId, x.SalesId });
                    table.ForeignKey(
                        name: "FK_ProductSale_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSale_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesAndDealers_DealerId",
                table: "SalesAndDealers",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceAndDealers_DealerId",
                table: "ProductPriceAndDealers",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DealerId",
                table: "Orders",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DealerId",
                table: "Employees",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerStocks_DealerId",
                table: "DealerStocks",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerProductPrice_ProductPricesId",
                table: "DealerProductPrice",
                column: "ProductPricesId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerSale_SalesId",
                table: "DealerSale",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_SalesId",
                table: "ProductSale",
                column: "SalesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerStocks_Dealers_DealerId",
                table: "DealerStocks",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Dealers_DealerId",
                table: "Employees",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dealers_DealerId",
                table: "Orders",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPriceAndDealers_Dealers_DealerId",
                table: "ProductPriceAndDealers",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesAndDealers_Dealers_DealerId",
                table: "SalesAndDealers",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
