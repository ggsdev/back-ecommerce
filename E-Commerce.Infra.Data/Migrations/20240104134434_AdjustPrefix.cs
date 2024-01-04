using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdjustPrefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product.Orders_ControlAccess.Users_BuyerId",
                table: "Product.Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product.Orders_PaymentMethod_PaymentMethodId",
                table: "Product.Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product.Orders_StatusOrder_StatusOrderId",
                table: "Product.Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Purcharse.OrderItemss_Product.Orders_OrderId",
                table: "Purcharse.OrderItemss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusOrder",
                table: "StatusOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product.Orders",
                table: "Product.Orders");

            migrationBuilder.RenameTable(
                name: "StatusOrder",
                newName: "Purcharse.StatusOrders");

            migrationBuilder.RenameTable(
                name: "Product.Orders",
                newName: "Purcharse.Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Product.Orders_StatusOrderId",
                table: "Purcharse.Orders",
                newName: "IX_Purcharse.Orders_StatusOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Product.Orders_PaymentMethodId",
                table: "Purcharse.Orders",
                newName: "IX_Purcharse.Orders_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Product.Orders_BuyerId",
                table: "Purcharse.Orders",
                newName: "IX_Purcharse.Orders_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purcharse.StatusOrders",
                table: "Purcharse.StatusOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purcharse.Orders",
                table: "Purcharse.Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purcharse.OrderItemss_Purcharse.Orders_OrderId",
                table: "Purcharse.OrderItemss",
                column: "OrderId",
                principalTable: "Purcharse.Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purcharse.Orders_ControlAccess.Users_BuyerId",
                table: "Purcharse.Orders",
                column: "BuyerId",
                principalTable: "ControlAccess.Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purcharse.Orders_PaymentMethod_PaymentMethodId",
                table: "Purcharse.Orders",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purcharse.Orders_Purcharse.StatusOrders_StatusOrderId",
                table: "Purcharse.Orders",
                column: "StatusOrderId",
                principalTable: "Purcharse.StatusOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purcharse.OrderItemss_Purcharse.Orders_OrderId",
                table: "Purcharse.OrderItemss");

            migrationBuilder.DropForeignKey(
                name: "FK_Purcharse.Orders_ControlAccess.Users_BuyerId",
                table: "Purcharse.Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Purcharse.Orders_PaymentMethod_PaymentMethodId",
                table: "Purcharse.Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Purcharse.Orders_Purcharse.StatusOrders_StatusOrderId",
                table: "Purcharse.Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purcharse.StatusOrders",
                table: "Purcharse.StatusOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purcharse.Orders",
                table: "Purcharse.Orders");

            migrationBuilder.RenameTable(
                name: "Purcharse.StatusOrders",
                newName: "StatusOrder");

            migrationBuilder.RenameTable(
                name: "Purcharse.Orders",
                newName: "Product.Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Purcharse.Orders_StatusOrderId",
                table: "Product.Orders",
                newName: "IX_Product.Orders_StatusOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Purcharse.Orders_PaymentMethodId",
                table: "Product.Orders",
                newName: "IX_Product.Orders_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Purcharse.Orders_BuyerId",
                table: "Product.Orders",
                newName: "IX_Product.Orders_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusOrder",
                table: "StatusOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product.Orders",
                table: "Product.Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product.Orders_ControlAccess.Users_BuyerId",
                table: "Product.Orders",
                column: "BuyerId",
                principalTable: "ControlAccess.Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product.Orders_PaymentMethod_PaymentMethodId",
                table: "Product.Orders",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product.Orders_StatusOrder_StatusOrderId",
                table: "Product.Orders",
                column: "StatusOrderId",
                principalTable: "StatusOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purcharse.OrderItemss_Product.Orders_OrderId",
                table: "Purcharse.OrderItemss",
                column: "OrderId",
                principalTable: "Product.Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
