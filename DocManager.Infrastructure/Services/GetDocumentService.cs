using DocManager.Domain.Entities;
using DocManager.Domain.Services;
using DocManager.InfrastructureEF.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DocManager.InfrastructureEF.Services;

public class GetDocumentService(Context context) : IGetDocumentService
{
    public async Task<Document?> GetDocumentById(Guid id, CancellationToken cancellationToken)
    => await context.Document.FirstOrDefaultAsync(et => et.Id.Equals(id), cancellationToken);

    public async Task<List<Document>> GetDocuments(CancellationToken cancellationToken)
    => await context.Document.ToListAsync(cancellationToken);

    public async Task<List<Document>> GetDocumentsByExpedienteId(Guid expedienteId, CancellationToken cancellationToken)
    => await context.Document.Where(d => d.ExpedienteId.Equals(expedienteId)).ToListAsync(cancellationToken);
}
