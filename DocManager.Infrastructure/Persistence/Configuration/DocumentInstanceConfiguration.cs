using DocManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocManager.InfrastructureEF.Persistence.Configuration;

public class DocumentInstanceConfiguration : IEntityTypeConfiguration<DocumentInstance>
{
    public void Configure(EntityTypeBuilder<DocumentInstance> builder)
    {
        builder.HasIndex(e => e.UniqueIdentifier).IsUnique();
        builder.HasOne(e => e.DocumentType)
              .WithMany()
              .HasForeignKey(e => e.DocumentTypeId)
              .OnDelete(DeleteBehavior.Restrict);
        builder.Property(e => e.FieldDataJson).HasColumnType("nvarchar(MAX)");
    }
}
