using System.ComponentModel;

namespace DataService.Api.Dtos;

public record BuscarNoticiasRequest(int EmpresaId, string DataInicial, string DataFinal)
{
    public int EmpresaId { get; } = EmpresaId;
    [DefaultValue("05/12/2021")] public string DataInicial { get; } = DataInicial;
    [DefaultValue("10/12/2021")] public string DataFinal { get; } = DataFinal;
}