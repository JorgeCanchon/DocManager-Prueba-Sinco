namespace DocManager.Domain.Entities;

public class DocumentFile : AuditableBaseEntity
{
    public Guid DocumentInstanceId { get; set; }
    public DocumentInstance DocumentInstance { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public string FileNameOriginal { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public uint FileSize { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    public string FilePath { get; set; } = null!;
    public string? FileHash { get; set; }
}