using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewEntitiesCategorySubItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CA.Infos_CA.Addresss_AddressId",
                table: "CA.Infos");

            migrationBuilder.DropForeignKey(
                name: "FK_CA.Sessions_CA.Users_UserId",
                table: "CA.Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_CA.Users_CA.Infos_InfoId",
                table: "CA.Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CA.Users",
                table: "CA.Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CA.Sessions",
                table: "CA.Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CA.Infos",
                table: "CA.Infos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CA.Addresss",
                table: "CA.Addresss");

            migrationBuilder.RenameTable(
                name: "CA.Users",
                newName: "ControlAccess.Users");

            migrationBuilder.RenameTable(
                name: "CA.Sessions",
                newName: "ControlAccess.Sessions");

            migrationBuilder.RenameTable(
                name: "CA.Infos",
                newName: "ControlAccess.Infos");

            migrationBuilder.RenameTable(
                name: "CA.Addresss",
                newName: "ControlAccess.Addresss");

            migrationBuilder.RenameIndex(
                name: "IX_CA.Users_InfoId",
                table: "ControlAccess.Users",
                newName: "IX_ControlAccess.Users_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_CA.Sessions_UserId",
                table: "ControlAccess.Sessions",
                newName: "IX_ControlAccess.Sessions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CA.Infos_Email",
                table: "ControlAccess.Infos",
                newName: "IX_ControlAccess.Infos_Email");

            migrationBuilder.RenameIndex(
                name: "IX_CA.Infos_Cellphone",
                table: "ControlAccess.Infos",
                newName: "IX_ControlAccess.Infos_Cellphone");

            migrationBuilder.RenameIndex(
                name: "IX_CA.Infos_AddressId",
                table: "ControlAccess.Infos",
                newName: "IX_ControlAccess.Infos_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ControlAccess.Users",
                table: "ControlAccess.Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ControlAccess.Sessions",
                table: "ControlAccess.Sessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ControlAccess.Infos",
                table: "ControlAccess.Infos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ControlAccess.Addresss",
                table: "ControlAccess.Addresss",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Product.Categorys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product.Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product.SubCategorys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product.SubCategorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product.SubCategorys_Product.Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Product.Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product.Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    SubCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product.Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product.Items_Product.SubCategorys_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "Product.SubCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product.Images",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    IsShowCase = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product.Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product.Images_Product.Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Product.Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product.Categorys_Name",
                table: "Product.Categorys",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product.Images_ItemId",
                table: "Product.Images",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Product.Items_Name",
                table: "Product.Items",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product.Items_SubCategoryId",
                table: "Product.Items",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product.SubCategorys_CategoryId",
                table: "Product.SubCategorys",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product.SubCategorys_Name",
                table: "Product.SubCategorys",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlAccess.Infos_ControlAccess.Addresss_AddressId",
                table: "ControlAccess.Infos",
                column: "AddressId",
                principalTable: "ControlAccess.Addresss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlAccess.Sessions_ControlAccess.Users_UserId",
                table: "ControlAccess.Sessions",
                column: "UserId",
                principalTable: "ControlAccess.Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlAccess.Users_ControlAccess.Infos_InfoId",
                table: "ControlAccess.Users",
                column: "InfoId",
                principalTable: "ControlAccess.Infos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlAccess.Infos_ControlAccess.Addresss_AddressId",
                table: "ControlAccess.Infos");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlAccess.Sessions_ControlAccess.Users_UserId",
                table: "ControlAccess.Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlAccess.Users_ControlAccess.Infos_InfoId",
                table: "ControlAccess.Users");

            migrationBuilder.DropTable(
                name: "Product.Images");

            migrationBuilder.DropTable(
                name: "Product.Items");

            migrationBuilder.DropTable(
                name: "Product.SubCategorys");

            migrationBuilder.DropTable(
                name: "Product.Categorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ControlAccess.Users",
                table: "ControlAccess.Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ControlAccess.Sessions",
                table: "ControlAccess.Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ControlAccess.Infos",
                table: "ControlAccess.Infos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ControlAccess.Addresss",
                table: "ControlAccess.Addresss");

            migrationBuilder.RenameTable(
                name: "ControlAccess.Users",
                newName: "CA.Users");

            migrationBuilder.RenameTable(
                name: "ControlAccess.Sessions",
                newName: "CA.Sessions");

            migrationBuilder.RenameTable(
                name: "ControlAccess.Infos",
                newName: "CA.Infos");

            migrationBuilder.RenameTable(
                name: "ControlAccess.Addresss",
                newName: "CA.Addresss");

            migrationBuilder.RenameIndex(
                name: "IX_ControlAccess.Users_InfoId",
                table: "CA.Users",
                newName: "IX_CA.Users_InfoId");

            migrationBuilder.RenameIndex(
                name: "IX_ControlAccess.Sessions_UserId",
                table: "CA.Sessions",
                newName: "IX_CA.Sessions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ControlAccess.Infos_Email",
                table: "CA.Infos",
                newName: "IX_CA.Infos_Email");

            migrationBuilder.RenameIndex(
                name: "IX_ControlAccess.Infos_Cellphone",
                table: "CA.Infos",
                newName: "IX_CA.Infos_Cellphone");

            migrationBuilder.RenameIndex(
                name: "IX_ControlAccess.Infos_AddressId",
                table: "CA.Infos",
                newName: "IX_CA.Infos_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CA.Users",
                table: "CA.Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CA.Sessions",
                table: "CA.Sessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CA.Infos",
                table: "CA.Infos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CA.Addresss",
                table: "CA.Addresss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CA.Infos_CA.Addresss_AddressId",
                table: "CA.Infos",
                column: "AddressId",
                principalTable: "CA.Addresss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CA.Sessions_CA.Users_UserId",
                table: "CA.Sessions",
                column: "UserId",
                principalTable: "CA.Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CA.Users_CA.Infos_InfoId",
                table: "CA.Users",
                column: "InfoId",
                principalTable: "CA.Infos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
