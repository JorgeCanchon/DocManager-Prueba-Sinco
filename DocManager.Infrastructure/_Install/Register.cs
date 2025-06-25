using DocManager.Domain.Services.Persistence;
using DocManager.InfrastructureEF.Persistence;
using DocManager.InfrastructureEF.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocManager.InfrastructureEF._Install;

public static class Register
{
    public static void AddInfraestructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DocManager.ConnectionString")!;

        services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));

        #region Repositories
        services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        #endregion
    }
}
