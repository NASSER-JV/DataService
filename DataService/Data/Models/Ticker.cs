namespace DataService.Data.Models;

public class Ticker
{
    public Ticker()
    {
        NoticiaAnaliseUrl = new HashSet<NoticiaAnalise>();
    }

    public string Nome { get; set; } = null!;

    public virtual ICollection<NoticiaAnalise> NoticiaAnaliseUrl { get; set; }
}