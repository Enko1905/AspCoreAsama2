using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 22, 3, 19, 10, 416, DateTimeKind.Local).AddTicks(578), "Bluetooth 5.0 destekli, gürültü engelleyici kulaklık.", 10m, false, 700m, "Kablosuz Kulaklık" },
                    { 2, new DateTime(2025, 8, 22, 3, 19, 10, 416, DateTimeKind.Local).AddTicks(580), "RGB aydınlatmalı, mavi switch mekanik klavye.", 5m, false, 30000m, "Mekanik Klavye" },
                    { 4, new DateTime(2025, 8, 22, 3, 19, 10, 416, DateTimeKind.Local).AddTicks(582), "Kalp ritmi ölçer, uyku takibi ve GPS destekli akıllı saat.", 15m, false, 50000m, "Akıllı Saat" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
