using DataService.App.Dtos;
using DataService.App.Queries;
using DataService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataService.App.QueryHandlers;

public class
    BuscarTarefasPorFinalizadoQueryHandler : IRequestHandler<BuscarTarefasPorFinalizadoQuery, List<TarefaResponse>>
{
    public BuscarTarefasPorFinalizadoQueryHandler(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<List<TarefaResponse>> Handle(BuscarTarefasPorFinalizadoQuery request,
        CancellationToken cancellationToken)
    {
        var tarefas = await Context.Tarefas.Where(tarefa => tarefa.Finalizado == request.Finalizado)
            .ToListAsync(cancellationToken);

        return tarefas.Select(TarefaResponse.FromModel).ToList();
    }
}