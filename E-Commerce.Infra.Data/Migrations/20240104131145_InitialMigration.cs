using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlAccess.Addresss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Complement = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    City = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    State = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    ZipCode = table.Column<string>(type: "char(9)", maxLength: 9, nullable: false),
                    Reference = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlAccess.Addresss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodValue = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product.Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product.Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product.Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product.Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanRate = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlAccess.Infos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cellphone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlAccess.Infos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlAccess.Infos_ControlAccess.Addresss_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ControlAccess.Addresss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product.SubCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
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
                name: "ControlAccess.Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Surname = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    InfoId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlAccess.Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlAccess.Users_ControlAccess.Infos_InfoId",
                        column: x => x.InfoId,
                        principalTable: "ControlAccess.Infos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product.Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product.Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product.Items_Product.Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Product.Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product.Items_Product.SubCategorys_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "Product.SubCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlAccess.Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlAccess.Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlAccess.Sessions_ControlAccess.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "ControlAccess.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product.Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EstimatedDeliverTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveredTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CanceledTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreightCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StatusOrderId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product.Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product.Orders_ControlAccess.Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "ControlAccess.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product.Orders_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product.Orders_StatusOrder_StatusOrderId",
                        column: x => x.StatusOrderId,
                        principalTable: "StatusOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product.Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImageContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Product.Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<byte>(type: "tinyint", nullable: false),
                    Comment = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product.Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product.Ratings_ControlAccess.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "ControlAccess.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product.Ratings_Product.Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Product.Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product.OrderItemss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<byte>(type: "tinyint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, computedColumnSql: "[Quantity] * [Price]"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product.OrderItemss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product.OrderItemss_Product.Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Product.Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product.OrderItemss_Product.Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Product.Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlAccess.Infos_AddressId",
                table: "ControlAccess.Infos",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlAccess.Infos_Cellphone",
                table: "ControlAccess.Infos",
                column: "Cellphone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlAccess.Infos_Email",
                table: "ControlAccess.Infos",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlAccess.Sessions_UserId",
                table: "ControlAccess.Sessions",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlAccess.Users_InfoId",
                table: "ControlAccess.Users",
                column: "InfoId",
                unique: true);

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
                name: "IX_Product.Items_StockId",
                table: "Product.Items",
                column: "StockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product.Items_SubCategoryId",
                table: "Product.Items",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product.OrderItemss_ItemId",
                table: "Product.OrderItemss",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Product.OrderItemss_OrderId",
                table: "Product.OrderItemss",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product.Orders_BuyerId",
                table: "Product.Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product.Orders_PaymentMethodId",
                table: "Product.Orders",
                column: "PaymentMethodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product.Orders_StatusOrderId",
                table: "Product.Orders",
                column: "StatusOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product.Ratings_ItemId",
                table: "Product.Ratings",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Product.Ratings_UserId",
                table: "Product.Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product.SubCategorys_CategoryId",
                table: "Product.SubCategorys",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product.SubCategorys_Name",
                table: "Product.SubCategorys",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlAccess.Sessions");

            migrationBuilder.DropTable(
                name: "Product.Images");

            migrationBuilder.DropTable(
                name: "Product.OrderItemss");

            migrationBuilder.DropTable(
                name: "Product.Ratings");

            migrationBuilder.DropTable(
                name: "Product.Orders");

            migrationBuilder.DropTable(
                name: "Product.Items");

            migrationBuilder.DropTable(
                name: "ControlAccess.Users");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "StatusOrder");

            migrationBuilder.DropTable(
                name: "Product.Stocks");

            migrationBuilder.DropTable(
                name: "Product.SubCategorys");

            migrationBuilder.DropTable(
                name: "ControlAccess.Infos");

            migrationBuilder.DropTable(
                name: "Product.Categorys");

            migrationBuilder.DropTable(
                name: "ControlAccess.Addresss");
        }
    }
}
