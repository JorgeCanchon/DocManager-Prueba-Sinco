using DocManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocManager.InfrastructureEF.Persistence.Configuration;

public class CustomFieldConfiguration : IEntityTypeConfiguration<CustomField>
{
    public void Configure(EntityTypeBuilder<CustomField> builder)
    {
        builder.HasOne(c => c.ExpedienteType)
                .WithMany(t => t.CustomFields)
                .HasForeignKey(c => c.ExpedienteTypeId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
