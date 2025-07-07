﻿using DocManager.Domain.Services.Persistence;

namespace DocManager.InfrastructureEF.Persistence.Repository;

public class RepositoryAsync<T>(Context dbContext) : RepositoryBase<T>(dbContext), IRepositoryAsync<T> where T : class
{
    private readonly Context _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
}