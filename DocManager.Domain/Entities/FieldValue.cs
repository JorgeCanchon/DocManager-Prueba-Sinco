namespace DocManager.Domain.Entities;

public class FieldValue : AuditableBaseEntity
{
    public string Value { get; set; } = null!;
    public Guid ExpedienteId { get; set; }
    public Expediente Expediente { get; set; } = null!;
    public Guid CustomFieldId { get; set; }
    public CustomField CustomField { get; set; } = null!;
}
