namespace DocManager.Domain.Entities;

public class FieldListOption : AuditableBaseEntity
{
    public Guid CustomFieldId { get; set; }
    public CustomField CustomField { get; set; } = null!;
    public string OptionValue { get; set; } = null!;
}
