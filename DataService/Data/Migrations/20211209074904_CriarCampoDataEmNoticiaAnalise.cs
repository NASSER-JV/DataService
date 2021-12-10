using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataService.Data.Migrations
{
    public partial class CriarCampoDataEmNoticiaAnalise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "data",
                table: "noticias_analise",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data",
                table: "noticias_analise");
        }
    }
}
