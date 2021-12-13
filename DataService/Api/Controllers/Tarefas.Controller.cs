using DataService.Api.Dtos;
using DataService.App.Commands;
using DataService.App.Dtos;
using DataService.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefasController : ControllerBase
{
    public TarefasController(IMediator mediator)
    {
        Mediator = mediator;
    }

    private IMediator Mediator { get; }

    [HttpPost]
    public async Task<ActionResult<TarefaResponse>> SalvarTarefa([FromBody] SalvarTarefaRequest payload)
    {
        var data = await Mediator.Send(new SalvarTarefaCommand(payload.Id, payload.Tipo, payload.Tickers,
            DateOnly.Parse(payload.DataInicial), DateOnly.Parse(payload.DataFinal), payload.Finalizado));

        return CreatedAtAction("SalvarTarefa", data);
    }

    [HttpGet]
    public async Task<ActionResult<List<TarefaResponse>>> BuscarTarefasPorFinalizado(
        [FromQuery] BuscarTarefasPorFinalizadoRequest query)
    {
        var data = await Mediator.Send(new BuscarTarefasPorFinalizadoQuery(query.Finalizado));

        return data;
    }
}