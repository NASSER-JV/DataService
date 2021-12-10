using DataService.App.Dtos;
using DataService.App.Queries;
using DataService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataService.App.QueryHandlers;

public class BuscarEmpresaPorCodigoQueryHandler : IRequestHandler<BuscarEmpresaPorCodigoQuery, EmpresaResponse?>
{
    public BuscarEmpresaPorCodigoQueryHandler(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<EmpresaResponse?> Handle(BuscarEmpresaPorCodigoQuery request, CancellationToken cancellationToken)
    {
        var empresa = await Context.Empresas
            .Where(empresa => empresa.Codigo == request.Codigo && empresa.Ativo == request.Ativo)
            .FirstOrDefaultAsync(cancellationToken);

        return empresa != null ? EmpresaResponse.FromModel(empresa) : null;
    }
}