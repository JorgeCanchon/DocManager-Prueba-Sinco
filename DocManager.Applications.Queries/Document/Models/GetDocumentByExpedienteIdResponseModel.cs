using DocumentEntity = DocManager.Domain.Entities.Document;

namespace DocManager.Applications.Queries.Document.Models;

public class GetDocumentByExpedienteIdResponseModel
{
    public List<DocumentEntity> Documents { get; set; } = [];
}
