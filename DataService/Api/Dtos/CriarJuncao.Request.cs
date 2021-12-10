using System.ComponentModel;

namespace DataService.Api.Dtos;

public record CriarJuncaoRequest(string DataInicio, string DataFinal, int EmpresaId)
{
    [DefaultValue("01/12/2021")] public string DataInicio { get; } = DataInicio;

    [DefaultValue("10/12/2021")] public string DataFinal { get; } = DataFinal;

    public int EmpresaId { get; } = EmpresaId;
}