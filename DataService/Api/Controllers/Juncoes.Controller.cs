using DataService.Api.Dtos;
using DataService.App.Commands;
using DataService.App.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JuncoesController : ControllerBase
{
    public JuncoesController(IMediator mediator)
    {
        Mediator = mediator;
    }

    private IMediator Mediator { get; }

    [HttpPost]
    public async Task<ActionResult<JuncaoResponse>> CriarJuncao([FromBody] CriarJuncaoRequest payload)
    {
        var (dataInicio, dataFinal, empresaId) = payload;
        var data = await Mediator.Send(new CriarJuncaoCommand(DateOnly.Parse(dataInicio),
            DateOnly.Parse(dataFinal), empresaId));

        return CreatedAtAction("CriarJuncao", data);
    }
}