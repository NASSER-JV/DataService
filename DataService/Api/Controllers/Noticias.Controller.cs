using DataService.Api.Dtos;
using DataService.App.Commands;
using DataService.App.Dtos;
using DataService.App.Queries;
using DataService.Data;
using DataService.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoticiasController : ControllerBase
{
    public NoticiasController(IMediator mediator)
    {
        Mediator = mediator;
    }
    
    private IMediator Mediator { get; }

    // GET: api/Noticias/5
    [HttpGet]
    public async Task<ActionResult<List<NoticiaResponse>>> BuscarNoticias([FromQuery] BuscarNoticiasRequest query)
    {
        var (empresaId, dataInicial, dataFinal) = query;
            
        var data = await Mediator.Send(new BuscarNoticiasQuery(empresaId, DateOnly.Parse(dataInicial),
            DateOnly.Parse(dataFinal)));

        return data;
    }

    // POST: api/Noticias
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<NoticiaResponse>> SalvarNoticia([FromBody] SalvarNoticiaRequest payload)
    {
        var data = await Mediator.Send(new SalvarNoticiaCommand(payload.Id, payload.Url, payload.Titulo, payload.Texto,
            DateOnly.Parse(payload.Data), payload.Sentimento, payload.Analise, payload.Peso, payload.EventoId, payload.EmpresaId));

        return CreatedAtAction("SalvarNoticia", data);
    }
}