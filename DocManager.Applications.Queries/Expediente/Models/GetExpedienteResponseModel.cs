using ExpedienteEntity = DocManager.Domain.Entities.Expediente;

namespace DocManager.Applications.Queries.Expediente.Models;

public class GetExpedienteResponseModel
{
    public List<ExpedienteEntity> Expedientes { get; set; } = [];
}
