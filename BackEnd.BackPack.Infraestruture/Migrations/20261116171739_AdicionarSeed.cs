using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.BackPack.Infraestruture.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventario_Itens_IdItem",
                table: "Inventario");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Durabilidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tamanho = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dureza = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Raridade = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    IdHistoria = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Historia_IdHistoria",
                        column: x => x.IdHistoria,
                        principalTable: "Historia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_IdHistoria",
                table: "Item",
                column: "IdHistoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventario_Item_IdItem",
                table: "Inventario",
                column: "IdItem",
                principalTable: "Item",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventario_Item_IdItem",
                table: "Inventario");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHistoria = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durabilidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dureza = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Raridade = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_Historia_IdHistoria",
                        column: x => x.IdHistoria,
                        principalTable: "Historia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itens_IdHistoria",
                table: "Itens",
                column: "IdHistoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventario_Itens_IdItem",
                table: "Inventario",
                column: "IdItem",
                principalTable: "Itens",
                principalColumn: "Id");
        }
    }
}
