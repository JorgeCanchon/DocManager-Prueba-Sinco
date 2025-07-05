namespace DocManager.Domain.Entities;

public class FieldListOption : AuditableBaseEntity
{
    public Guid DocumentTypeFieldId { get; set; }
    public DocumentTypeField DocumentTypeField { get; set; } = null!;
    public string OptionValue { get; set; } = null!;
}
