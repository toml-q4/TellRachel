using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TellRachel.Migrations
{
    public partial class link_temperature_to_note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NoteId",
                table: "Temperatures",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_NoteId",
                table: "Temperatures",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Temperatures_Notes_NoteId",
                table: "Temperatures",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temperatures_Notes_NoteId",
                table: "Temperatures");

            migrationBuilder.DropIndex(
                name: "IX_Temperatures_NoteId",
                table: "Temperatures");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Temperatures");
        }
    }
}
