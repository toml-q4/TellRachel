using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TellRachel.Migrations
{
    public partial class split_temperature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemperatureInCelsius",
                table: "Symptoms");

            migrationBuilder.AddColumn<Guid>(
                name: "TemperatureId",
                table: "Symptoms",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsFahrenheit = table.Column<bool>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_TemperatureId",
                table: "Symptoms",
                column: "TemperatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_Temperatures_TemperatureId",
                table: "Symptoms",
                column: "TemperatureId",
                principalTable: "Temperatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_Temperatures_TemperatureId",
                table: "Symptoms");

            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropIndex(
                name: "IX_Symptoms_TemperatureId",
                table: "Symptoms");

            migrationBuilder.DropColumn(
                name: "TemperatureId",
                table: "Symptoms");

            migrationBuilder.AddColumn<double>(
                name: "TemperatureInCelsius",
                table: "Symptoms",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
