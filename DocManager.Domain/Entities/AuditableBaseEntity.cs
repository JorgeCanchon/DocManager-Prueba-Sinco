﻿namespace DocManager.Domain.Entities;

public class AuditableBaseEntity : BaseEntity
{
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}
