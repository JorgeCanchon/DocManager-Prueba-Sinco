namespace DocManager.Domain.Entities;

public class Expediente : AuditableBaseEntity
{
    public Guid ExpedienteTypeId { get; set; }
    public ExpedienteType ExpedienteType { get; set; } = null!;
    public string UniqueIdentifier { get; set; } = Guid.NewGuid().ToString();
    public ICollection<FieldValue> FieldValues { get; set; } = [];
    public ICollection<Document> Documents { get; set; } = [];
}
