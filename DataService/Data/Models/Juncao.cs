namespace DataService.Data.Models;

public class Juncao
{
    public int Id { get; set; }
    public DateOnly DataInicio { get; set; }
    public DateOnly DataFinal { get; set; }
    public int EmpresaId { get; set; }

    public virtual Empresa Empresa { get; set; } = null!;
}