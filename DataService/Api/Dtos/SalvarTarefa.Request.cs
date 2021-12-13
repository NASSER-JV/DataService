using System.ComponentModel;
using DataService.Data.Models.Enums;

namespace DataService.Api.Dtos;

public record SalvarTarefaRequest(int? Id, TipoTarefa Tipo, string[] Tickers, string DataInicial, string DataFinal,
    bool? Finalizado)
{
    public int? Id { get; } = Id;
    public TipoTarefa Tipo { get; } = Tipo;
    public string[] Tickers { get; } = Tickers;
    [DefaultValue("01/12/2021")] public string DataInicial { get; } = DataInicial;
    [DefaultValue("10/12/2021")] public string DataFinal { get; } = DataFinal;
    public bool? Finalizado { get; } = Finalizado;
}