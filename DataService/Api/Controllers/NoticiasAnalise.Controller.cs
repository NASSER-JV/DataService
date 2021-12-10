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

[Route("api/noticias-analise")]
[ApiController]
public class NoticiasAnaliseController : ControllerBase
{
    public NoticiasAnaliseController(IMediator mediator)
    {
        Mediator = mediator;
    }
    
    private IMediator Mediator { get; }

    // GET: api/NoticiasAnalise
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NoticiaAnaliseResponse>>> BuscarNoticiasAnalise()
    {
        var data = await Mediator.Send(new BuscarNoticiasAnaliseQuery());

        return data;
    }

    // POST: api/NoticiasAnalise
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<NoticiaAnaliseResponse>> CriarNoticiaAnalise(CriarNoticiaAnaliseRequest payload)
    {
        var data = await Mediator.Send(new CriarNoticiaAnaliseCommand(payload.Url, payload.Titulo, payload.Texto, DateOnly.Parse(payload.Data), 
            payload.Sentimento, payload.Tickers));

        return CreatedAtAction("CriarNoticiaAnalise", data);
    }
}