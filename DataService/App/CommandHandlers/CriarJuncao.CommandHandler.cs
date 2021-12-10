using DataService.App.Commands;
using DataService.App.Dtos;
using DataService.Data;
using DataService.Data.Models;
using MediatR;

namespace DataService.App.CommandHandlers;

public class CriarJuncaoCommandHandler : IRequestHandler<CriarJuncaoCommand, JuncaoResponse>
{
    public CriarJuncaoCommandHandler(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<JuncaoResponse> Handle(CriarJuncaoCommand request, CancellationToken cancellationToken)
    {
        var juncao = new Juncao
        {
            DataInicio = request.DataInicial,
            DataFinal = request.DataFinal,
            EmpresaId = request.EmpresaId
        };

        Context.Juncoes.Add(juncao);
        await Context.SaveChangesAsync(cancellationToken);

        return JuncaoResponse.FromModel(juncao);
    }
}