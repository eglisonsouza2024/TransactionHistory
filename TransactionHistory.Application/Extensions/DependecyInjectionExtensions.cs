using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TransactionHistory.Application.Messages.Extracts.Queries;
using TransactionHistory.Core.Mediator.Handler;

namespace TransactionHistory.Application.Extensions
{
    public static class DependecyInjectionExtensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetExtractQuery).GetTypeInfo().Assembly));
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            return services;
        }
    }
}
