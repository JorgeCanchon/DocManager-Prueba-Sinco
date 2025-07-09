using ExpedienteEntity = DocManager.Domain.Entities.Expediente;

namespace DocManager.Applications.Queries.Expediente.Models;

public class GetExpedienteByIdResponseModel
{
    public ExpedienteEntity Expediente { get; set; } = null!;
}