﻿namespace DocManager.Domain.Services.Persistence;

public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
{
}

public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
{

}
