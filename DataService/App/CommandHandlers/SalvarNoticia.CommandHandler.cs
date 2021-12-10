using DataService.App.Commands;
using DataService.App.Dtos;
using DataService.Data;
using DataService.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DataService.App.CommandHandlers;

public class SalvarNoticiaCommandHandler : IRequestHandler<SalvarNoticiaCommand, NoticiaResponse>
{
    public SalvarNoticiaCommandHandler(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<NoticiaResponse> Handle(SalvarNoticiaCommand request, CancellationToken cancellationToken)
    {
        var noticia = await Context.Noticias.Where(noticia => noticia.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        var noticiaExiste = true;

        if (noticia is null)
        {
            noticia = new Noticia
            {
                Id = request.Id
            };
            noticiaExiste = false;
        }

        noticia.Url = request.Url;
        noticia.Titulo = request.Titulo;
        noticia.Texto = request.Texto;
        noticia.Data = request.Data;
        noticia.Sentimento = request.Sentimento;
        noticia.Analise = request.Analise;
        noticia.Peso = request.Peso;
        noticia.EventoId = request.EventoId;
        noticia.EmpresaId = request.EmpresaId;

        Context.Noticias.Update(noticia);

        if (!noticiaExiste)
        {
            Context.Entry(noticia).State = EntityState.Added;
        }
        
        await Context.SaveChangesAsync(cancellationToken);

        return NoticiaResponse.FromModel(noticia);
    }
}