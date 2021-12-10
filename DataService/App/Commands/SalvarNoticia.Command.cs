using DataService.App.Dtos;
using MediatR;

namespace DataService.App.Commands;

public class SalvarNoticiaCommand : IRequest<NoticiaResponse>
{
    public SalvarNoticiaCommand(int id, string url, string titulo, string texto, DateOnly data, int sentimento, int? analise,
        decimal? peso, string? eventoId, int empresaId)
    {
        Id = id;
        Url = url;
        Titulo = titulo;
        Texto = texto;
        Data = data;
        Sentimento = sentimento;
        Analise = analise;
        Peso = peso;
        EventoId = eventoId;
        EmpresaId = empresaId;
    }

    public int Id { get; }
    public string Url { get; }
    public string Titulo { get; }
    public string Texto { get; }
    public DateOnly Data { get; }
    public int Sentimento { get; }
    public int? Analise { get; }
    public decimal? Peso { get; }
    public string? EventoId { get; }
    public int EmpresaId { get; }
}