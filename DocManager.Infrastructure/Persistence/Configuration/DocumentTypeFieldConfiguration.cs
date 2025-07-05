using DocManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocManager.InfrastructureEF.Persistence.Configuration;

public class DocumentTypeFieldConfiguration : IEntityTypeConfiguration<DocumentTypeField>
{
    public void Configure(EntityTypeBuilder<DocumentTypeField> builder)
    {
        builder.HasOne(c => c.DocumentType)
                .WithMany(t => t.Fields)
                .HasForeignKey(c => c.DocumentTypeId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
