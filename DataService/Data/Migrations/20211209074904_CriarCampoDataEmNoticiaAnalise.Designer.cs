﻿// <auto-generated />
using System;
using DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataService.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211209074904_CriarCampoDataEmNoticiaAnalise")]
    partial class CriarCampoDataEmNoticiaAnalise
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataService.Data.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("codigo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("empresas", (string)null);
                });

            modelBuilder.Entity("DataService.Data.Models.Juncao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataFinal")
                        .HasPrecision(0)
                        .HasColumnType("date")
                        .HasColumnName("data_final");

                    b.Property<DateOnly>("DataInicio")
                        .HasPrecision(0)
                        .HasColumnType("date")
                        .HasColumnName("data_inicio");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("integer")
                        .HasColumnName("empresa_id");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("juncoes", (string)null);
                });

            modelBuilder.Entity("DataService.Data.Models.Noticia", b =>
                {
                    b.Property<string>("Url")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.Property<int?>("Analise")
                        .HasColumnType("integer")
                        .HasColumnName("analise")
                        .HasComment("Analise do ML");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date")
                        .HasColumnName("data");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("integer")
                        .HasColumnName("empresa_id");

                    b.Property<int>("Sentimento")
                        .HasColumnType("integer")
                        .HasColumnName("sentimento");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("texto");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("titulo");

                    b.HasKey("Url")
                        .HasName("noticias_pkey");

                    b.HasIndex("EmpresaId");

                    b.ToTable("noticias", (string)null);
                });

            modelBuilder.Entity("DataService.Data.Models.NoticiaAnalise", b =>
                {
                    b.Property<string>("Url")
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date")
                        .HasColumnName("data");

                    b.Property<int>("Sentimento")
                        .HasColumnType("integer")
                        .HasColumnName("sentimento");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("texto");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("titulo");

                    b.HasKey("Url")
                        .HasName("noticias_analise_pkey");

                    b.ToTable("noticias_analise", (string)null);
                });

            modelBuilder.Entity("DataService.Data.Models.Ticker", b =>
                {
                    b.Property<string>("Nome")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("nome");

                    b.HasKey("Nome")
                        .HasName("tickers_pkey");

                    b.ToTable("tickers", (string)null);
                });

            modelBuilder.Entity("NoticiasAnaliseTickers", b =>
                {
                    b.Property<string>("NoticiaAnaliseUrl")
                        .HasColumnType("text")
                        .HasColumnName("noticia_analise_url");

                    b.Property<string>("TickerNome")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ticker_nome");

                    b.HasKey("NoticiaAnaliseUrl", "TickerNome")
                        .HasName("noticias_analise_tickers_pkey");

                    b.HasIndex("TickerNome");

                    b.ToTable("noticias_analise_tickers", (string)null);
                });

            modelBuilder.Entity("DataService.Data.Models.Juncao", b =>
                {
                    b.HasOne("DataService.Data.Models.Empresa", "Empresa")
                        .WithMany("Juncoes")
                        .HasForeignKey("EmpresaId")
                        .IsRequired()
                        .HasConstraintName("juncoes_empresa_id_foreign");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("DataService.Data.Models.Noticia", b =>
                {
                    b.HasOne("DataService.Data.Models.Empresa", "Empresa")
                        .WithMany("Noticias")
                        .HasForeignKey("EmpresaId")
                        .IsRequired()
                        .HasConstraintName("noticias_empresa_id_foreign");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("NoticiasAnaliseTickers", b =>
                {
                    b.HasOne("DataService.Data.Models.NoticiaAnalise", null)
                        .WithMany()
                        .HasForeignKey("NoticiaAnaliseUrl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("noticias_analise_tickers_noticia_analise_url_foreign");

                    b.HasOne("DataService.Data.Models.Ticker", null)
                        .WithMany()
                        .HasForeignKey("TickerNome")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("noticias_analise_tickers_ticker_nome_foreign");
                });

            modelBuilder.Entity("DataService.Data.Models.Empresa", b =>
                {
                    b.Navigation("Juncoes");

                    b.Navigation("Noticias");
                });
#pragma warning restore 612, 618
        }
    }
}
