using DataService.App.Dtos;
using MediatR;

namespace DataService.App.Queries;

public class BuscarNoticiasAnaliseQuery : IRequest<List<NoticiaAnaliseResponse>>
{}