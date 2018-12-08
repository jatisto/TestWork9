using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TestWork9.Data.Migrations
{
    public partial class AddNewEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddBalanceId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddBalances",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SumAdd = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddBalances", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddBalanceId",
                table: "AspNetUsers",
                column: "AddBalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AddBalances_AddBalanceId",
                table: "AspNetUsers",
                column: "AddBalanceId",
                principalTable: "AddBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AddBalances_AddBalanceId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AddBalances");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddBalanceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddBalanceId",
                table: "AspNetUsers");
        }
    }
}
