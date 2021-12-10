using DataService.Data.Models;

namespace DataService.App.Dtos;

public class NoticiaResponse
{
    public NoticiaResponse(int id, string url, string titulo, string texto, string data, int sentimento, int? analise,
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
    public string Data { get; }
    public int Sentimento { get; }
    public int? Analise { get; }
    public decimal? Peso { get; }
    public string? EventoId { get; }
    public int EmpresaId { get; }

    public static NoticiaResponse FromModel(Noticia model)
    {
        return new NoticiaResponse(model.Id, model.Url, model.Titulo, model.Texto, model.Data.ToString("dd/MM/yyyy"),
            model.Sentimento, model.Analise, model.Peso, model.EventoId, model.EmpresaId);
    }
}