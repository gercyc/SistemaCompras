using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Categoria = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Situacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacaoCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioSolicitante = table.Column<string>(nullable: true),
                    NomeFornecedor = table.Column<string>(nullable: true),
                    CondicaoPagamento = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    TotalGeral = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Situacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoCompra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSolicitacaoCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true),
                    Qtde = table.Column<int>(nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SolicitacaoCompraId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSolicitacaoCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSolicitacaoCompra_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemSolicitacaoCompra_SolicitacaoCompra_SolicitacaoCompraId",
                        column: x => x.SolicitacaoCompraId,
                        principalTable: "SolicitacaoCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSolicitacaoCompra_ProdutoId",
                table: "ItemSolicitacaoCompra",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSolicitacaoCompra_SolicitacaoCompraId",
                table: "ItemSolicitacaoCompra",
                column: "SolicitacaoCompraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemSolicitacaoCompra");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "SolicitacaoCompra");
        }
    }
}
