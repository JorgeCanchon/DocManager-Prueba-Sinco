using DocManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocManager.InfrastructureEF.Persistence.Configuration;

public class DocumentFileConfiguration : IEntityTypeConfiguration<DocumentFile>
{
    public void Configure(EntityTypeBuilder<DocumentFile> builder)
    {
        builder.HasOne(d => d.DocumentInstance)
                .WithMany(e => e.Documents)
                .HasForeignKey(d => d.DocumentInstanceId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
