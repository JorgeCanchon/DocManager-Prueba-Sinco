using DocumentEntity = DocManager.Domain.Entities.Document;

namespace DocManager.Applications.Queries.Document.Models;

public class GetDocumentByIdResponseModel
{
    public DocumentEntity Document { get; set; } = null!;
}
