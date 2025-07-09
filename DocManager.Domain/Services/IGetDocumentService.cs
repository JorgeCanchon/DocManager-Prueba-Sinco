using DocumentEntity = DocManager.Domain.Entities.Document;

namespace DocManager.Domain.Services;

public interface IGetDocumentService
{
    public Task<List<DocumentEntity>> GetDocuments(CancellationToken cancellationToken);
    public Task<DocumentEntity?> GetDocumentById(Guid id, CancellationToken cancellationToken);
}
