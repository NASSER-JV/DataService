namespace DataService.Data.Models;

public class Empresa
{
    public Empresa()
    {
        Juncoes = new HashSet<Juncao>();
        Noticias = new HashSet<Noticia>();
    }

    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Codigo { get; set; } = null!;
    public bool Ativo { get; set; }

    public virtual ICollection<Juncao> Juncoes { get; set; }
    public virtual ICollection<Noticia> Noticias { get; set; }
}