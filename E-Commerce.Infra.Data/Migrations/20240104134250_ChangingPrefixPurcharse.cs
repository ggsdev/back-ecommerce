using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingPrefixPurcharse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product.OrderItemss_Product.Items_ItemId",
                table: "Product.OrderItemss");

            migrationBuilder.DropForeignKey(
                name: "FK_Product.OrderItemss_Product.Orders_OrderId",
                table: "Product.OrderItemss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product.OrderItemss",
                table: "Product.OrderItemss");

            migrationBuilder.RenameTable(
                name: "Product.OrderItemss",
                newName: "Purcharse.OrderItemss");

            migrationBuilder.RenameIndex(
                name: "IX_Product.OrderItemss_OrderId",
                table: "Purcharse.OrderItemss",
                newName: "IX_Purcharse.OrderItemss_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Product.OrderItemss_ItemId",
                table: "Purcharse.OrderItemss",
                newName: "IX_Purcharse.OrderItemss_ItemId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product.Items",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purcharse.OrderItemss",
                table: "Purcharse.OrderItemss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purcharse.OrderItemss_Product.Items_ItemId",
                table: "Purcharse.OrderItemss",
                column: "ItemId",
                principalTable: "Product.Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purcharse.OrderItemss_Product.Orders_OrderId",
                table: "Purcharse.OrderItemss",
                column: "OrderId",
                principalTable: "Product.Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purcharse.OrderItemss_Product.Items_ItemId",
                table: "Purcharse.OrderItemss");

            migrationBuilder.DropForeignKey(
                name: "FK_Purcharse.OrderItemss_Product.Orders_OrderId",
                table: "Purcharse.OrderItemss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purcharse.OrderItemss",
                table: "Purcharse.OrderItemss");

            migrationBuilder.RenameTable(
                name: "Purcharse.OrderItemss",
                newName: "Product.OrderItemss");

            migrationBuilder.RenameIndex(
                name: "IX_Purcharse.OrderItemss_OrderId",
                table: "Product.OrderItemss",
                newName: "IX_Product.OrderItemss_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Purcharse.OrderItemss_ItemId",
                table: "Product.OrderItemss",
                newName: "IX_Product.OrderItemss_ItemId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product.Items",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product.OrderItemss",
                table: "Product.OrderItemss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product.OrderItemss_Product.Items_ItemId",
                table: "Product.OrderItemss",
                column: "ItemId",
                principalTable: "Product.Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product.OrderItemss_Product.Orders_OrderId",
                table: "Product.OrderItemss",
                column: "OrderId",
                principalTable: "Product.Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
