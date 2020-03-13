using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UmHelp_Teste.WebApi.Migrations
{
    public partial class UmHelp_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeProduto = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Valor = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    QtdEstoque = table.Column<decimal>(type: "DECIMAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
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
                    IdTiposUsuarios = table.Column<int>(nullable: false),
                    IdTipoUsuarios = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuarios_IdTipoUsuarios",
                        column: x => x.IdTipoUsuarios,
                        principalTable: "TiposUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Desconto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false),
                    IdUsuarios = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desconto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desconto_Usuarios_IdUsuarios",
                        column: x => x.IdUsuarios,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
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
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Usuarios_IdUsuarios",
                        column: x => x.IdUsuarios,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "NomeProduto", "QtdEstoque", "Valor" },
                values: new object[,]
                {
                    { 1, "Candida", 35m, 50m },
                    { 2, "Cloro", 40m, 60m }
                });

            migrationBuilder.InsertData(
                table: "TiposUsuarios",
                columns: new[] { "Id", "Titulo" },
                values: new object[,]
                {
                    { 1, "Adm" },
                    { 2, "Comum" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "IdTipoUsuarios", "IdTiposUsuarios", "Senha" },
                values: new object[,]
                {
                    { 1, "adm@adm.com", null, 1, "adm123" },
                    { 2, "comum@comum.com", null, 2, "comum132" }
                });

            migrationBuilder.InsertData(
                table: "Desconto",
                columns: new[] { "Id", "Ativo", "IdUsuarios", "Valor" },
                values: new object[] { 1, true, 1, 30m });

            migrationBuilder.InsertData(
                table: "Desconto",
                columns: new[] { "Id", "Ativo", "IdUsuarios", "Valor" },
                values: new object[] { 2, true, 2, 20m });

            migrationBuilder.CreateIndex(
                name: "IX_Desconto_IdUsuarios",
                table: "Desconto",
                column: "IdUsuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdProduto",
                table: "Pedido",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdUsuarios",
                table: "Pedido",
                column: "IdUsuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoUsuarios",
                table: "Usuarios",
                column: "IdTipoUsuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desconto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposUsuarios");
        }
    }
}
