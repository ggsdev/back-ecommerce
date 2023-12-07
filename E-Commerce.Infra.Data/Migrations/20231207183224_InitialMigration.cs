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
                name: "CA.Addresss",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Complement = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    City = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    State = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    ZipCode = table.Column<string>(type: "char(9)", maxLength: 9, nullable: false),
                    Reference = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CA.Addresss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CA.Infos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cellphone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CA.Infos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CA.Infos_CA.Addresss_AddressId",
                        column: x => x.AddressId,
                        principalTable: "CA.Addresss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CA.Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Surname = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Age = table.Column<short>(type: "smallint", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    InfoId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CA.Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CA.Users_CA.Infos_InfoId",
                        column: x => x.InfoId,
                        principalTable: "CA.Infos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CA.Infos_AddressId",
                table: "CA.Infos",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CA.Users_InfoId",
                table: "CA.Users",
                column: "InfoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CA.Users");

            migrationBuilder.DropTable(
                name: "CA.Infos");

            migrationBuilder.DropTable(
                name: "CA.Addresss");
        }
    }
}
