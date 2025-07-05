using DocManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocManager.InfrastructureEF.Persistence.Configuration;

public class ExpedienteConfiguration : IEntityTypeConfiguration<Expediente>
{
    public void Configure(EntityTypeBuilder<Expediente> builder)
    {
        builder.HasIndex(e => e.UniqueIdentifier).IsUnique();
        builder.HasOne(e => e.ExpedienteType)
              .WithMany()
              .HasForeignKey(e => e.ExpedienteTypeId)
              .OnDelete(DeleteBehavior.Restrict);
        builder.Property(e => e.FieldDataJson).HasColumnType("nvarchar(MAX)");
    }
}
