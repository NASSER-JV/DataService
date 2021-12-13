using DataService.App.Commands;
using DataService.App.Dtos;
using DataService.Data;
using DataService.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataService.App.CommandHandlers;

public class SalvarTarefaCommandHandler : IRequestHandler<SalvarTarefaCommand, TarefaResponse>
{
    public SalvarTarefaCommandHandler(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<TarefaResponse> Handle(SalvarTarefaCommand request, CancellationToken cancellationToken)
    {
        var tarefa = new Tarefa();

        if (request.Id is not null)
            tarefa = await Context.Tarefas.FirstOrDefaultAsync(tarefa => tarefa.Id == request.Id, cancellationToken) ??
                     tarefa;

        tarefa.Tipo = request.Tipo;
        tarefa.Tickers = request.Tickers;
        tarefa.DataInicial = request.DataInicial;
        tarefa.DataFinal = request.DataFinal;
        tarefa.Finalizado = request.Finalizado ?? false;

        Context.Update(tarefa);
        await Context.SaveChangesAsync(cancellationToken);

        return TarefaResponse.FromModel(tarefa);
    }
}