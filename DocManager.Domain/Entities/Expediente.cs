namespace DocManager.Domain.Entities;

public class Expediente : AuditableBaseEntity
{
    public Guid ExpedienteTypeId { get; set; }
    public ExpedienteType ExpedienteType { get; set; } = null!;
    public string UniqueIdentifier { get; set; } = null!;
    public string? FieldDataJson { get; set; }
    public ICollection<Document> Documents { get; set; } = [];
}
