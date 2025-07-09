using ExpedienteTypeEntity = DocManager.Domain.Entities.ExpedienteType;

namespace DocManager.Applications.Queries.ExpedienteType.Models;

public class GetExpedienteTypeByIdResponseModel
{
    public ExpedienteTypeEntity ExpedienteTypeEntity { get; set; } = null!;
}
