using ExpedienteEntity = DocManager.Domain.Entities.Expediente;

namespace DocManager.Domain.Services;

public interface IGetExpedienteService
{
    public Task<List<ExpedienteEntity>> GetExpedienteWithFieldsAndValues(CancellationToken cancellationToken);
    public Task<ExpedienteEntity?> GetExpedienteByIdWithFieldsAndValues(Guid id, CancellationToken cancellationToken);
}
