using DataService.App.Dtos;
using MediatR;

namespace DataService.App.Commands;

public class CriarNoticiaAnaliseCommand : IRequest<NoticiaAnaliseResponse>
{
    public CriarNoticiaAnaliseCommand(string url, string titulo, string texto, DateOnly data, int sentimento, List<string> tickers)
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
    public DateOnly Data { get; }
    public int Sentimento { get; }
    public List<string> Tickers { get; }
}