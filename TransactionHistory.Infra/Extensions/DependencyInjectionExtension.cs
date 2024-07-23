using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionHistory.Infra.Persistence;

namespace TransactionHistory.Infra.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TransactionHistoryDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("TransactionHistoryContext"),
                    b => b.MigrationsAssembly(typeof(TransactionHistoryDbContext).Assembly.FullName)));

            return services;
        }
    }
}
