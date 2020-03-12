using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioUmHelp.WebApi.Migrations
{
    public partial class UmHelp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeProduto = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Valor = table.Column<decimal>(type: "DECIMAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    IdTiposUsuarios = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuarios_Id",
                        column: x => x.Id,
                        principalTable: "TiposUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DescontosDeProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdUsuarios = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescontosDeProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescontosDeProdutos_Usuarios_IdUsuarios",
                        column: x => x.IdUsuarios,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ValorProduto = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    IdUsuarios = table.Column<int>(nullable: false),
                    IdProduto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_IdUsuarios",
                        column: x => x.IdUsuarios,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescontosDeProdutos_IdUsuarios",
                table: "DescontosDeProdutos",
                column: "IdUsuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdProduto",
                table: "Pedidos",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdUsuarios",
                table: "Pedidos",
                column: "IdUsuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescontosDeProdutos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposUsuarios");
        }
    }
}
