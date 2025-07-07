namespace DocManager.Domain.Entities;

public class Document : AuditableBaseEntity
{
    public Guid ExpedienteId { get; set; }
    public Expediente Expediente { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public string FileNameOriginal { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public uint FileSize { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    public string FilePath { get; set; } = null!;
    public string? FileHash { get; set; }
}