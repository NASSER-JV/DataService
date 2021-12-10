namespace DataService.Data.Models;

public class Noticia
{
    public int Id { get; set; }
    public string Url { get; set; } = null!;
    public string Titulo { get; set; } = null!;
    public string Texto { get; set; } = null!;
    public DateOnly Data { get; set; }
    public int Sentimento { get; set; }
    /// <summary>
    ///     Analise do ML
    /// </summary>
    public int? Analise { get; set; }
    public decimal? Peso { get; set; }
    public string? EventoId { get; set; }
    public int EmpresaId { get; set; }

    public virtual Empresa? Empresa { get; set; } = null;
}