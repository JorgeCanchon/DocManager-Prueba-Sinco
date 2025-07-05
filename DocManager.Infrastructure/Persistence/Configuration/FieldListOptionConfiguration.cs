using DocManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocManager.InfrastructureEF.Persistence.Configuration;

public class FieldListOptionConfiguration : IEntityTypeConfiguration<FieldListOption>
{
    public void Configure(EntityTypeBuilder<FieldListOption> builder)
    {
        builder.HasOne(o => o.DocumentTypeField)
                .WithMany(c => c.Options)
                .HasForeignKey(o => o.DocumentTypeFieldId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
