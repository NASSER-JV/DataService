using DataService.App.Dtos;
using MediatR;

namespace DataService.App.Commands;

public class CriarJuncaoCommand : IRequest<JuncaoResponse>
{
    public CriarJuncaoCommand(DateOnly dataInicial, DateOnly dataFinal, int empresaId)
    {
        DataInicial = dataInicial;
        DataFinal = dataFinal;
        EmpresaId = empresaId;
    }


    public DateOnly DataInicial { get; }
    public DateOnly DataFinal { get; }
    public int EmpresaId { get; }
}