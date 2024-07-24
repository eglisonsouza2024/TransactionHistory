using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TransactionHistory.Domain.Repository;
using TransactionHistory.Infra.Persistence;
using TransactionHistory.Infra.Persistence.Repositories;

namespace TransactionHistory.Infra.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TransactionHistoryDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("TransactionHistoryContext"),
                    b => b.MigrationsAssembly(typeof(TransactionHistoryDbContext).Assembly.FullName)));

            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }
    }
}
