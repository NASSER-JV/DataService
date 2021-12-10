using DataService.App.Dtos;
using DataService.App.Queries;
using DataService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataService.App.QueryHandlers;

public class BuscarNoticiasAnaliseQueryHandler : IRequestHandler<BuscarNoticiasAnaliseQuery, List<NoticiaAnaliseResponse>>
{
    public BuscarNoticiasAnaliseQueryHandler(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }
    
    public async Task<List<NoticiaAnaliseResponse>> Handle(BuscarNoticiasAnaliseQuery request, CancellationToken cancellationToken)
    {
        var noticiasAnalise = await Context.NoticiasAnalise.Include(noticiaAnalise => noticiaAnalise.TickerNome)
            .ToListAsync(cancellationToken);

        return noticiasAnalise.Select(NoticiaAnaliseResponse.FromModel).ToList();
    }
}