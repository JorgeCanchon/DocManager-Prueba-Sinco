using DocManager.Domain.Entities;

namespace DocManager.Domain.Services;

public interface IGetExpedienteTypeService
{
    Task<List<ExpedienteType>> GetExpedienteTypeWithCustomFields(CancellationToken cancellationToken);
    Task<ExpedienteType?> GetExpedienteTypeByIdWithCustomFields(Guid expedienteTypeId, CancellationToken cancellationToken);
}
