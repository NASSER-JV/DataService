using DataService.App.Dtos;
using MediatR;

namespace DataService.App.Queries;

public class BuscarTodasEmpresasQuery : IRequest<List<EmpresaResponse>>
{
}