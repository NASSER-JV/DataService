using DataService.App.Dtos;
using MediatR;

namespace DataService.App.Queries;

public class BuscarEmpresaPorCodigoQuery : IRequest<EmpresaResponse?>
{
    public BuscarEmpresaPorCodigoQuery(string codigo, bool ativo)
    {
        Codigo = codigo;
        Ativo = ativo;
    }

    public string Codigo { get; }
    public bool Ativo { get; }
}