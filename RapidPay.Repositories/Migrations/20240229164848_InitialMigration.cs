using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RapidPay.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RapidPay");

            migrationBuilder.CreateTable(
                name: "Cards",
                schema: "RapidPay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numbers = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CardHolder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    ExpirationMonth = table.Column<int>(type: "int", nullable: false),
                    ExpirationYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "RapidPay",
                table: "Cards",
                columns: new[] { "Id", "Balance", "CVV", "CardHolder", "ExpirationMonth", "ExpirationYear", "Numbers" },
                values: new object[] { new Guid("0ee32853-371a-4a5b-85e8-4155bfb15919"), 10000.0, 123, "Maxi", 1, 2027, "123456789012345" });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Numbers",
                schema: "RapidPay",
                table: "Cards",
                column: "Numbers",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards",
                schema: "RapidPay");
        }
    }
}
