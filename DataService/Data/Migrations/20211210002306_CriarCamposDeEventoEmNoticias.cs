using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataService.Data.Migrations
{
    public partial class CriarCamposDeEventoEmNoticias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "noticias_pkey",
                table: "noticias");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "noticias",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "evento_id",
                table: "noticias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "peso",
                table: "noticias",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "noticias_pkey",
                table: "noticias",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "noticias_pkey",
                table: "noticias");

            migrationBuilder.DropColumn(
                name: "id",
                table: "noticias");

            migrationBuilder.DropColumn(
                name: "evento_id",
                table: "noticias");

            migrationBuilder.DropColumn(
                name: "peso",
                table: "noticias");

            migrationBuilder.AddPrimaryKey(
                name: "noticias_pkey",
                table: "noticias",
                column: "url");
        }
    }
}
