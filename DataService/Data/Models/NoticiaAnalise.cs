namespace DataService.Data.Models;

public class NoticiaAnalise
{
    public NoticiaAnalise()
    {
        TickerNome = new HashSet<Ticker>();
    }

    public string Url { get; set; } = null!;
    public string Titulo { get; set; } = null!;
    public string Texto { get; set; } = null!;
    public DateOnly Data { get; set; }
    public int Sentimento { get; set; }

    public virtual ICollection<Ticker> TickerNome { get; set; }
}