namespace DocManager.Domain.Entities;

public class DocumentType : AuditableBaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<DocumentTypeField> Fields { get; set; } = [];
}
