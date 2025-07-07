using DocManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocManager.InfrastructureEF.Persistence.Configuration;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasOne(d => d.Expediente)
                .WithMany(e => e.Documents)
                .HasForeignKey(d => d.ExpedienteId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
