using DataService.App.Dtos;
using MediatR;

namespace DataService.App.Queries;

public class BuscarNoticiasQuery : IRequest<List<NoticiaResponse>>
{
    public BuscarNoticiasQuery(int empresaId, DateOnly dataInicial, DateOnly dataFinal)
    {
        EmpresaId = empresaId;
        DataInicial = dataInicial;
        DataFinal = dataFinal;
    }

    public int EmpresaId { get; }
    public DateOnly DataInicial { get; }
    public DateOnly DataFinal { get; }
}