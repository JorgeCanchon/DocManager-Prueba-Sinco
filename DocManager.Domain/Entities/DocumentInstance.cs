namespace DocManager.Domain.Entities;

public class DocumentInstance : AuditableBaseEntity
{
    public Guid DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; } = null!;
    public string UniqueIdentifier { get; set; } = null!;
    public string? FieldDataJson { get; set; }
    public ICollection<DocumentFile> Documents { get; set; } = [];
}
