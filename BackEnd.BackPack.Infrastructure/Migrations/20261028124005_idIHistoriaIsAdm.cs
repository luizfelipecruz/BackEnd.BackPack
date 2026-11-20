using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.BackPack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class idIHistoriaIsAdm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdHistoria",
                table: "Itens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_IdHistoria",
                table: "Itens",
                column: "IdHistoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Historia_IdHistoria",
                table: "Itens",
                column: "IdHistoria",
                principalTable: "Historia",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Historia_IdHistoria",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_IdHistoria",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "IdHistoria",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "Admin",
                table: "AspNetUsers");
        }
    }
}
