using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TestWork9.Data.Migrations
{
    public partial class DeleteCashAndAddPropertyBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cash");

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Cash",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cash_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cash_UserId",
                table: "Cash",
                column: "UserId");
        }
    }
}
