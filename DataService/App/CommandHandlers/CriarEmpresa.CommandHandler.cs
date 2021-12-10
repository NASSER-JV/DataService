using DataService.App.Commands;
using DataService.App.Dtos;
using DataService.Data;
using DataService.Data.Models;
using MediatR;

namespace DataService.App.CommandHandlers;

public class CriarEmpresaCommandHandler : IRequestHandler<CriarEmpresaCommand, EmpresaResponse>
{
    public CriarEmpresaCommandHandler(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<EmpresaResponse> Handle(CriarEmpresaCommand request, CancellationToken cancellationToken)
    {
        var empresa = new Empresa
        {
            Ativo = true,
            Codigo = request.Codigo,
            Nome = request.Nome
        };

        Context.Empresas.Add(empresa);
        await Context.SaveChangesAsync(cancellationToken);

        return EmpresaResponse.FromModel(empresa);
    }
}