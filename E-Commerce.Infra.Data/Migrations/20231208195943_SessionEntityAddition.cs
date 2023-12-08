using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SessionEntityAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CA.Sessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CA.Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CA.Sessions_CA.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "CA.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CA.Infos_Cellphone",
                table: "CA.Infos",
                column: "Cellphone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CA.Infos_Email",
                table: "CA.Infos",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CA.Sessions_UserId",
                table: "CA.Sessions",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CA.Sessions");

            migrationBuilder.DropIndex(
                name: "IX_CA.Infos_Cellphone",
                table: "CA.Infos");

            migrationBuilder.DropIndex(
                name: "IX_CA.Infos_Email",
                table: "CA.Infos");
        }
    }
}
