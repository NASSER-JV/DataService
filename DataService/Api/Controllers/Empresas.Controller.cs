using DataService.Api.Dtos;
using DataService.App.Commands;
using DataService.App.Dtos;
using DataService.App.Queries;
using DataService.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpresasController : ControllerBase
{
    public EmpresasController(IMediator mediator)
    {
        Mediator = mediator;
    }

    private IMediator Mediator { get; }

    // GET: api/Empresas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmpresaResponse>>> BuscarTodasEmpresas()
    {
        var data = await Mediator.Send(new BuscarTodasEmpresasQuery());

        return data;
    }

    // GET: api/Empresas/5
    [HttpGet("filtrar")]
    public async Task<ActionResult<EmpresaResponse?>> BuscarEmpresaPorCodigo(
        [FromQuery] BuscarEmpresaPorSiglaRequest filtro)
    {
        var data = await Mediator.Send(new BuscarEmpresaPorCodigoQuery(filtro.Sigla, filtro.Ativo));

        return data;
    }

    // POST: api/Empresas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<EmpresaResponse>> CriarEmpresa(CriarEmpresaRequest payload)
    {
        var (nome, codigo) = payload;

        var data = await Mediator.Send(new CriarEmpresaCommand(nome, codigo));

        return CreatedAtAction("CriarEmpresa", data);
    }
}