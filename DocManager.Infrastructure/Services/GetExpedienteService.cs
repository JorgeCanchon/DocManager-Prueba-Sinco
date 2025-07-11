using DocManager.Domain.Entities;
using DocManager.Domain.Services;
using DocManager.InfrastructureEF.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DocManager.InfrastructureEF.Services;

public class GetExpedienteService(Context context) : IGetExpedienteService
{
    public async Task<Expediente?> GetExpedienteByIdWithFieldsAndValues(Guid id, CancellationToken cancellationToken)
    => await context.Expediente
            .Include(e => e.FieldValues).ThenInclude(fv => fv.CustomField)
            .Include(e => e.Documents)
            .Include(e => e.ExpedienteType)
        .FirstOrDefaultAsync(et => et.Id.Equals(id), cancellationToken);

    public async Task<List<Expediente>> GetExpedienteWithFieldsAndValues(CancellationToken cancellationToken)
    => await context.Expediente
            .Include(e => e.FieldValues).ThenInclude(fv => fv.CustomField)
            .Include(e => e.Documents)
            .Include(e => e.ExpedienteType)
        .ToListAsync(cancellationToken);
}
