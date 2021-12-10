using DataService.App.Dtos;
using DataService.App.Queries;
using DataService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataService.App.QueryHandlers;

public class BuscarNoticiasQueryHandler : IRequestHandler<BuscarNoticiasQuery, List<NoticiaResponse>>
{
    public BuscarNoticiasQueryHandler(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<List<NoticiaResponse>> Handle(BuscarNoticiasQuery request, CancellationToken cancellationToken)
    {
        var noticias = await Context.Noticias
            .Where(noticia => noticia.EmpresaId == request.EmpresaId && noticia.Data >= request.DataInicial &&
                              noticia.Data <= request.DataFinal).ToListAsync(cancellationToken);

        return noticias.Select(NoticiaResponse.FromModel).ToList();
    }
}