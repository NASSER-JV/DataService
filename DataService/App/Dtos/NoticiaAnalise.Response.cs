using DataService.Data.Models;

namespace DataService.App.Dtos;

public class NoticiaAnaliseResponse
{
    public NoticiaAnaliseResponse(string url, string titulo, string texto, string data, int sentimento, List<string> tickers)
    {
        Url = url;
        Titulo = titulo;
        Texto = texto;
        Data = data;
        Sentimento = sentimento;
        Tickers = tickers;
    }
    
    public string Url { get; }
    public string Titulo { get; }
    public string Texto { get; }
    public string Data { get; }
    public int Sentimento { get; }
    public List<string> Tickers { get; }

    public static NoticiaAnaliseResponse FromModel(NoticiaAnalise model)
    {
        return new NoticiaAnaliseResponse(model.Url, model.Titulo, model.Texto, model.Data.ToString("dd/MM/yyyy"), model.Sentimento,
            model.TickerNome.Select(ticker => ticker.Nome).ToList());
    }
}