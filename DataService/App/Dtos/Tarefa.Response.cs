using DataService.Data.Models;
using DataService.Data.Models.Enums;

namespace DataService.App.Dtos;

public class TarefaResponse
{
    public TarefaResponse(int id, TipoTarefa tipo, string[] tickers, string dataInicial, string dataFinal,
        bool finalizado)
    {
        Id = id;
        Tipo = tipo;
        Tickers = tickers;
        DataInicial = dataInicial;
        DataFinal = dataFinal;
        Finalizado = finalizado;
    }

    public int Id { get; }
    public TipoTarefa Tipo { get; }
    public string[] Tickers { get; }
    public string DataInicial { get; }
    public string DataFinal { get; }
    public bool Finalizado { get; }

    public static TarefaResponse FromModel(Tarefa model)
    {
        return new TarefaResponse(model.Id, model.Tipo, model.Tickers, model.DataInicial.ToString("dd/MM/yyyy"),
            model.DataFinal.ToString("dd/MM/yyyy"), model.Finalizado);
    }
}