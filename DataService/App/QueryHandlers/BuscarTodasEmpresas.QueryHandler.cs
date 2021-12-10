using DataService.App.Dtos;
using DataService.App.Queries;
using DataService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataService.App.QueryHandlers;

public class BuscarTodasEmpresasQueryHandler : IRequestHandler<BuscarTodasEmpresasQuery, List<EmpresaResponse>>
{
    public BuscarTodasEmpresasQueryHandler(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<List<EmpresaResponse>> Handle(BuscarTodasEmpresasQuery request,
        CancellationToken cancellationToken)
    {
        var empresas = await Context.Empresas.ToListAsync(cancellationToken);

        return empresas.Select(EmpresaResponse.FromModel).ToList();
    }
}