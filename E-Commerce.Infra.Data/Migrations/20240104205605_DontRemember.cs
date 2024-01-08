using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class DontRemember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentMethods_PaymentMethodId",
                schema: "Purcharse",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethods",
                schema: "Payment",
                table: "PaymentMethods");

            migrationBuilder.RenameTable(
                name: "PaymentMethods",
                schema: "Payment",
                newName: "PaymentMethod",
                newSchema: "Payment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethod",
                schema: "Payment",
                table: "PaymentMethod",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PaymentMethod_PaymentMethodId",
                schema: "Purcharse",
                table: "Order",
                column: "PaymentMethodId",
                principalSchema: "Payment",
                principalTable: "PaymentMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentMethod_PaymentMethodId",
                schema: "Purcharse",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethod",
                schema: "Payment",
                table: "PaymentMethod");

            migrationBuilder.RenameTable(
                name: "PaymentMethod",
                schema: "Payment",
                newName: "PaymentMethods",
                newSchema: "Payment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethods",
                schema: "Payment",
                table: "PaymentMethods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PaymentMethods_PaymentMethodId",
                schema: "Purcharse",
                table: "Order",
                column: "PaymentMethodId",
                principalSchema: "Payment",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
