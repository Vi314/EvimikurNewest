using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealerModelSaleModel");

            migrationBuilder.DropTable(
                name: "ProductModelSaleModel");

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

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DealerModelId",
                table: "Sales",
                column: "DealerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductModelId",
                table: "Sales",
                column: "ProductModelId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Dealers_DealerModelId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_ProductModelId",
                table: "Sales");

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
                name: "IX_DealerModelSaleModel_SalesId",
                table: "DealerModelSaleModel",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelSaleModel_SalesId",
                table: "ProductModelSaleModel",
                column: "SalesId");
        }
    }
}
