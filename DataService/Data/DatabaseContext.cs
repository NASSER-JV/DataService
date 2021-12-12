using DataService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empresa> Empresas { get; set; } = null!;
    public virtual DbSet<Juncao> Juncoes { get; set; } = null!;
    public virtual DbSet<Noticia> Noticias { get; set; } = null!;
    public virtual DbSet<NoticiaAnalise> NoticiasAnalise { get; set; } = null!;
    public virtual DbSet<Ticker> Tickers { get; set; } = null!;
    public virtual DbSet<Tarefa> Tarefas { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(
                "Server=127.0.0.1;Port=5444;Database=tcc_news_analysis;User Id=postgres;Password=postgres;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.ToTable("empresas");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Ativo).HasColumnName("ativo");

            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .HasColumnName("codigo");

            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Juncao>(entity =>
        {
            entity.ToTable("juncoes");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.DataFinal)
                .HasPrecision(0)
                .HasColumnName("data_final");

            entity.Property(e => e.DataInicio)
                .HasPrecision(0)
                .HasColumnName("data_inicio");

            entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");

            entity.HasOne(d => d.Empresa)
                .WithMany(p => p.Juncoes)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("juncoes_empresa_id_foreign");
        });

        modelBuilder.Entity<Noticia>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("noticias_pkey");

            entity.ToTable("noticias");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Url).HasColumnName("url");

            entity.Property(e => e.Analise)
                .HasColumnName("analise")
                .HasComment("Analise do ML");

            entity.Property(e => e.Texto).HasColumnName("texto");

            entity.Property(e => e.Data)
                .HasColumnName("data");

            entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");

            entity.Property(e => e.Sentimento).HasColumnName("sentimento");

            entity.Property(e => e.Peso).HasColumnName("peso");

            entity.Property(e => e.EventoId).HasColumnName("evento_id");

            entity.Property(e => e.Titulo).HasColumnName("titulo");

            entity.HasOne(d => d.Empresa)
                .WithMany(p => p.Noticias)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("noticias_empresa_id_foreign");
        });

        modelBuilder.Entity<NoticiaAnalise>(entity =>
        {
            entity.HasKey(e => e.Url)
                .HasName("noticias_analise_pkey");

            entity.ToTable("noticias_analise");

            entity.Property(e => e.Url).HasColumnName("url");

            entity.Property(e => e.Data).HasColumnName("data");

            entity.Property(e => e.Sentimento).HasColumnName("sentimento");

            entity.Property(e => e.Texto).HasColumnName("texto");

            entity.Property(e => e.Titulo).HasColumnName("titulo");

            entity.HasMany(d => d.TickerNome)
                .WithMany(p => p.NoticiaAnaliseUrl)
                .UsingEntity<Dictionary<string, object>>(
                    "NoticiasAnaliseTickers",
                    l => l.HasOne<Ticker>().WithMany().HasForeignKey("TickerNome")
                        .HasConstraintName("noticias_analise_tickers_ticker_nome_foreign"),
                    r => r.HasOne<NoticiaAnalise>().WithMany().HasForeignKey("NoticiaAnaliseUrl")
                        .HasConstraintName("noticias_analise_tickers_noticia_analise_url_foreign"),
                    j =>
                    {
                        j.HasKey("NoticiaAnaliseUrl", "TickerNome").HasName("noticias_analise_tickers_pkey");

                        j.ToTable("noticias_analise_tickers");

                        j.IndexerProperty<string>("NoticiaAnaliseUrl").HasColumnName("noticia_analise_url");

                        j.IndexerProperty<string>("TickerNome").HasMaxLength(255).HasColumnName("ticker_nome");
                    });
        });

        modelBuilder.Entity<Ticker>(entity =>
        {
            entity.HasKey(e => e.Nome)
                .HasName("tickers_pkey");

            entity.ToTable("tickers");

            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("tarefas_pkey");

            entity.ToTable("tarefas");

            entity.Property(e => e.Tipo)
                .HasColumnName("tipo");

            entity.Property(e => e.Tickers)
                .HasColumnName("tickers");

            entity.Property(e => e.DataInicial)
                .HasColumnName("data_inicial");

            entity.Property(e => e.DataFinal)
                .HasColumnName("data_final");

            entity.Property(e => e.Finalizado)
                .HasColumnName("finalizado");
        });
    }
}