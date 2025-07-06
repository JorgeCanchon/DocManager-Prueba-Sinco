using DocManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocManager.InfrastructureEF.Persistence.Configuration;

public class FieldValueConfiguration : IEntityTypeConfiguration<FieldValue>
{
    public void Configure(EntityTypeBuilder<FieldValue> builder)
    {
        builder.HasOne(d => d.Expediente)
            .WithMany(e => e.FieldValues)
            .HasForeignKey(d => d.ExpedienteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
