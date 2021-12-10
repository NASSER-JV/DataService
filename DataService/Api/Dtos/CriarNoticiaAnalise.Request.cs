using System.ComponentModel;

namespace DataService.Api.Dtos;

public record CriarNoticiaAnaliseRequest(string Url, string Titulo, string Texto, string Data, int Sentimento, List<string> Tickers)
{
    public string Url { get; } = Url;
    public string Titulo { get; } = Titulo;
    public string Texto { get; } = Texto;
    [DefaultValue("01/12/2021")] public string Data { get; } = Data;
    public int Sentimento { get; } = Sentimento;
    public List<string> Tickers { get; } = Tickers;
}