using System.ComponentModel;

namespace DataService.Api.Dtos;

public record SalvarNoticiaRequest(int Id, string Url, string Titulo, string Texto, string Data, int Sentimento, int? Analise, decimal? Peso, string? EventoId, int EmpresaId)
{
    public int Id { get; } = Id;
    public string Url { get; } = Url;
    public string Titulo { get; } = Titulo;
    public string Texto { get; } = Texto;
    [DefaultValue("29/11/2021")] public string Data { get; } = Data;
    public int Sentimento { get; } = Sentimento;
    public int? Analise { get; } = Analise;
    public decimal? Peso { get; } = Peso;
    public string? EventoId { get; } = EventoId;
    public int EmpresaId { get; } = EmpresaId;
}