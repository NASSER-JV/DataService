using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataService.Data.Migrations
{
    public partial class BancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empresas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    codigo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "noticias_analise",
                columns: table => new
                {
                    url = table.Column<string>(type: "text", nullable: false),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    texto = table.Column<string>(type: "text", nullable: false),
                    sentimento = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("noticias_analise_pkey", x => x.url);
                });

            migrationBuilder.CreateTable(
                name: "tickers",
                columns: table => new
                {
                    nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tickers_pkey", x => x.nome);
                });

            migrationBuilder.CreateTable(
                name: "juncoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_inicio = table.Column<DateOnly>(type: "date", precision: 0, nullable: false),
                    data_final = table.Column<DateOnly>(type: "date", precision: 0, nullable: false),
                    empresa_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_juncoes", x => x.id);
                    table.ForeignKey(
                        name: "juncoes_empresa_id_foreign",
                        column: x => x.empresa_id,
                        principalTable: "empresas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "noticias",
                columns: table => new
                {
                    url = table.Column<string>(type: "text", nullable: false),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    texto = table.Column<string>(type: "text", nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false),
                    sentimento = table.Column<int>(type: "integer", nullable: false),
                    analise = table.Column<int>(type: "integer", nullable: true, comment: "Analise do ML"),
                    empresa_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("noticias_pkey", x => x.url);
                    table.ForeignKey(
                        name: "noticias_empresa_id_foreign",
                        column: x => x.empresa_id,
                        principalTable: "empresas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "noticias_analise_tickers",
                columns: table => new
                {
                    noticia_analise_url = table.Column<string>(type: "text", nullable: false),
                    ticker_nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("noticias_analise_tickers_pkey", x => new { x.noticia_analise_url, x.ticker_nome });
                    table.ForeignKey(
                        name: "noticias_analise_tickers_noticia_analise_url_foreign",
                        column: x => x.noticia_analise_url,
                        principalTable: "noticias_analise",
                        principalColumn: "url",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "noticias_analise_tickers_ticker_nome_foreign",
                        column: x => x.ticker_nome,
                        principalTable: "tickers",
                        principalColumn: "nome",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_juncoes_empresa_id",
                table: "juncoes",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_noticias_empresa_id",
                table: "noticias",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_noticias_analise_tickers_ticker_nome",
                table: "noticias_analise_tickers",
                column: "ticker_nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "juncoes");

            migrationBuilder.DropTable(
                name: "noticias");

            migrationBuilder.DropTable(
                name: "noticias_analise_tickers");

            migrationBuilder.DropTable(
                name: "empresas");

            migrationBuilder.DropTable(
                name: "noticias_analise");

            migrationBuilder.DropTable(
                name: "tickers");
        }
    }
}
