using DataService.App.Commands;
using DataService.App.Dtos;
using DataService.Data;
using DataService.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataService.App.CommandHandlers;

public class CriarNoticiaAnaliseCommandHandler : IRequestHandler<CriarNoticiaAnaliseCommand, NoticiaAnaliseResponse>
{
    public CriarNoticiaAnaliseCommandHandler(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }
    
    public async Task<NoticiaAnaliseResponse> Handle(CriarNoticiaAnaliseCommand request, CancellationToken cancellationToken)
    {
        var noticiaAnalise = new NoticiaAnalise
        {
            Url = request.Url,
            Titulo = request.Titulo,
            Texto = request.Texto,
            Data = request.Data,
            Sentimento = request.Sentimento,
            TickerNome = await MontarTickers(request.Tickers)
        };

        Context.NoticiasAnalise.Add(noticiaAnalise);
        await Context.SaveChangesAsync(cancellationToken);
        
        return NoticiaAnaliseResponse.FromModel(noticiaAnalise);
    }

    private async Task<List<Ticker>> MontarTickers(IEnumerable<string> tickers)
    {
        var tickersPersitido = new List<Ticker>();

        foreach (var ticker in tickers)
        {
            tickersPersitido.Add(await Context.Tickers.FirstOrDefaultAsync(tickerDb => tickerDb.Nome == ticker) ??
                                 new Ticker { Nome = ticker });
        }

        return tickersPersitido;
    }
}