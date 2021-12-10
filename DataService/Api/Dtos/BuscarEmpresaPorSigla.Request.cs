namespace DataService.Dtos;

public record BuscarEmpresaPorSiglaRequest(string Sigla, bool Ativo = true)
{
    public string Sigla { get; } = Sigla;
    public bool Ativo { get; } = Ativo;
}