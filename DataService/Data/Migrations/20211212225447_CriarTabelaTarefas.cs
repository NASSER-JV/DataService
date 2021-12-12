using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataService.Data.Migrations
{
    public partial class CriarTabelaTarefas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    tickers = table.Column<string[]>(type: "text[]", nullable: false),
                    data_inicial = table.Column<DateOnly>(type: "date", nullable: false),
                    data_final = table.Column<DateOnly>(type: "date", nullable: false),
                    finalizado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tarefas_pkey", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tarefas");
        }
    }
}
