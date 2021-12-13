using DataService.App.Dtos;
using MediatR;

namespace DataService.App.Queries;

public class BuscarTarefasPorFinalizadoQuery : IRequest<List<TarefaResponse>>
{
    public BuscarTarefasPorFinalizadoQuery(bool finalizado)
    {
        Finalizado = finalizado;
    }


    public bool Finalizado { get; }
}