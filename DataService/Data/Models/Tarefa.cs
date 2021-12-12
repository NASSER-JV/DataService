using DataService.Data.Models.Enums;

namespace DataService.Data.Models;

public class Tarefa
{
    public int Id { get; set; }
    public TipoTarefa Tipo { get; set; }
    public string[] Tickers { get; set; } = null!;
    public DateOnly DataInicial { get; set; }
    public DateOnly DataFinal { get; set; }
    public bool Finalizado { get; set; }
}