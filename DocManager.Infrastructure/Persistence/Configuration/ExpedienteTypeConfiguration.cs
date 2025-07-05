using DocManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocManager.InfrastructureEF.Persistence.Configuration;

public class ExpedienteTypeConfiguration : IEntityTypeConfiguration<ExpedienteType>
{
    public void Configure(EntityTypeBuilder<ExpedienteType> builder)
    {
        builder.HasIndex(e => e.Name).IsUnique();
    }
}
