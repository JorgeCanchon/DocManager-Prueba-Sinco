using DocManager.Domain.Entities;
using DocManager.Domain.Services;
using DocManager.Domain.Services.Persistence;
using DocManager.InfrastructureEF.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DocManager.InfrastructureEF.Services;

public class GetExpedienteTypeService(Context context) : IGetExpedienteTypeService
{
    public async Task<ExpedienteType?> GetExpedienteTypeByIdWithCustomFields(Guid expedienteTypeId, CancellationToken cancellationToken)
    => await context.ExpedienteType.Include(x => x.CustomFields)
        .ThenInclude(x => x.Options)
        .FirstOrDefaultAsync(et => et.Id.Equals(expedienteTypeId), cancellationToken);

    public async Task<List<ExpedienteType>> GetExpedienteTypeWithCustomFields(CancellationToken cancellationToken)
    => await context.ExpedienteType.Include(x => x.CustomFields)
        .ThenInclude(x => x.Options)
        .ToListAsync(cancellationToken);
}
