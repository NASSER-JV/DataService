using DataService.Data.Models;

namespace DataService.App.Dtos;

public class JuncaoResponse
{
    public JuncaoResponse(int id, string dataInicial, string dataFinal, int empresaId)
    {
        Id = id;
        DataInicial = dataInicial;
        DataFinal = dataFinal;
        EmpresaId = empresaId;
    }


    public int Id { get; }
    public string DataInicial { get; }
    public string DataFinal { get; }
    public int EmpresaId { get; }

    public static JuncaoResponse FromModel(Juncao model)
    {
        return new JuncaoResponse(model.Id, model.DataInicio.ToString("dd/MM/yyyy"),
            model.DataFinal.ToString("dd/MM/yyyy"), model.EmpresaId);
    }
}