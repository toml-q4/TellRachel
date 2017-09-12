using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TellRachel.Migrations
{
    public partial class Add_Common_Medicine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Caution",
                table: "Medicines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "Medicines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Medicines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Maker",
                table: "Medicines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductOverview",
                table: "Medicines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductUrl",
                table: "Medicines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseUrl",
                table: "Medicines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Warning",
                table: "Medicines",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommonMedicines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Caution = table.Column<string>(nullable: true),
                    Dosage = table.Column<string>(nullable: true),
                    Ingredients = table.Column<string>(nullable: true),
                    Maker = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    ProductOverview = table.Column<string>(nullable: true),
                    ProductUrl = table.Column<string>(nullable: true),
                    PurchaseUrl = table.Column<string>(nullable: true),
                    Warning = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonMedicines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonMedicines");

            migrationBuilder.DropColumn(
                name: "Caution",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Maker",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ProductOverview",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ProductUrl",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "PurchaseUrl",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Warning",
                table: "Medicines");
        }
    }
}
