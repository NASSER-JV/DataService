using DataService.App.Dtos;
using DataService.Data.Models.Enums;
using MediatR;

namespace DataService.App.Commands;

public class SalvarTarefaCommand : IRequest<TarefaResponse>
{
    public SalvarTarefaCommand(int? id, TipoTarefa tipo, string[] tickers, DateOnly dataInicial, DateOnly dataFinal,
        bool? finalizado)
    {
        Id = id;
        Tipo = tipo;
        Tickers = tickers;
        DataInicial = dataInicial;
        DataFinal = dataFinal;
        Finalizado = finalizado;
    }

    public int? Id { get; }
    public TipoTarefa Tipo { get; }
    public string[] Tickers { get; }
    public DateOnly DataInicial { get; }
    public DateOnly DataFinal { get; }
    public bool? Finalizado { get; }
}