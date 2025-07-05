using DocManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DocManager.InfrastructureEF.Persistence;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<DocumentType> DocumentType { get; set; } = null!;
    public DbSet<DocumentTypeField> DocumentTypeField { get; set; } = null!;
    public DbSet<FieldListOption> FieldListOption { get; set; } = null!;
    public DbSet<DocumentInstance> DocumentInstance { get; set; } = null!;
    public DbSet<DocumentFile> DocumentFile { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ChangeTracker.Entries<AuditableBaseEntity>().ToList().ForEach(entry =>
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.UtcNow;
                    break;
            }
        });
        return base.SaveChangesAsync(cancellationToken);
    }
}