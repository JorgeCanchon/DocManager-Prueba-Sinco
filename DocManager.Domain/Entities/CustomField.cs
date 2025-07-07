using DocManager.Domain.Shared.Enums;

namespace DocManager.Domain.Entities;

public class CustomField : AuditableBaseEntity
{
    public Guid ExpedienteTypeId { get; set; }
    public ExpedienteType ExpedienteType { get; set; } = null!;
    public string FieldName { get; set; } = null!;
    public DataType DataType { get; set; }
    public bool IsRequired { get; set; }
    public int Order { get; set; } = 0;
    public ICollection<FieldListOption> Options { get; set; } = [];
}
