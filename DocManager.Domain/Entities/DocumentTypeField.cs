namespace DocManager.Domain.Entities;

public class DocumentTypeField : AuditableBaseEntity
{
    public Guid DocumentTypeId { get; set; }
    public DocumentType DocumentType { get; set; } = null!;
    public string FieldName { get; set; } = null!;
    public string DataType { get; set; } = null!;
    public bool IsRequired { get; set; }
    public int Order { get; set; } = 0;
    public ICollection<FieldListOption> Options { get; set; } = [];
}
