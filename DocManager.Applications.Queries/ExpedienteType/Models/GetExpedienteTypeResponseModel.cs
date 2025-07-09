using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;

namespace DocManager.Applications.Queries.ExpedienteType.Models;

public class GetExpedienteTypeResponseModel
{
    public List<ExpedienteTypeEntity> ExpedienteTypes { get; set; } = [];
}
