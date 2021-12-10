using DataService.Data.Models;

namespace DataService.App.Dtos;

public class EmpresaResponse
{
    public EmpresaResponse(int id, string nome, string codigo, bool ativo)
    {
        Id = id;
        Nome = nome;
        Codigo = codigo;
        Ativo = ativo;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Codigo { get; set; }
    public bool Ativo { get; set; }

    public static EmpresaResponse FromModel(Empresa model)
    {
        return new EmpresaResponse(model.Id, model.Nome, model.Codigo, model.Ativo);
    }
}