namespace DocManager.Domain.Entities;

public class ExpedienteType : AuditableBaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<CustomField> CustomFields { get; set; } = [];
}
