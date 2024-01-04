using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingCategoryToHaveChildren : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_SubCategory_SubCategoryId",
                schema: "Product",
                table: "Item");

            migrationBuilder.DropTable(
                name: "SubCategory",
                schema: "Product");

            migrationBuilder.AddColumn<bool>(
                name: "IsParent",
                schema: "Product",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                schema: "Product",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                schema: "Product",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                schema: "Product",
                table: "Category",
                column: "ParentCategoryId",
                principalSchema: "Product",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_SubCategoryId",
                schema: "Product",
                table: "Item",
                column: "SubCategoryId",
                principalSchema: "Product",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                schema: "Product",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_SubCategoryId",
                schema: "Product",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Category_ParentCategoryId",
                schema: "Product",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IsParent",
                schema: "Product",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                schema: "Product",
                table: "Category");

            migrationBuilder.CreateTable(
                name: "SubCategory",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Product",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                schema: "Product",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_Name",
                schema: "Product",
                table: "SubCategory",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SubCategory_SubCategoryId",
                schema: "Product",
                table: "Item",
                column: "SubCategoryId",
                principalSchema: "Product",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
