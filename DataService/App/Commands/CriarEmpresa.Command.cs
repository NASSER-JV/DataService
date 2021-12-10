using DataService.App.Dtos;
using MediatR;

namespace DataService.App.Commands;

public class CriarEmpresaCommand : IRequest<EmpresaResponse>
{
    public CriarEmpresaCommand(string nome, string codigo)
    {
        Nome = nome;
        Codigo = codigo;
    }

    public string Nome { get; set; }
    public string Codigo { get; set; }
}