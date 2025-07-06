using DocManager.Domain.Services;
using DocManager.Domain.Services.Persistence;
using DocManager.InfrastructureEF.Persistence;
using DocManager.InfrastructureEF.Persistence.Repository;
using DocManager.InfrastructureEF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static DocManager.InfrastructureEF.Constants.Constants;

namespace DocManager.InfrastructureEF._Install;

public static class Register
{
    public static void AddInfraestructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(ConnectionStringName)!;

        services.AddDbContext<Context>(options => options.UseSqlServer(connectionString, npgsqlOptions => {
            npgsqlOptions.CommandTimeout(60);
        }), ServiceLifetime.Transient);

        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        services.AddTransient<IGetExpedienteTypeService, GetExpedienteTypeService>();
    }
}
