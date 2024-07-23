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
            //services.AddAutoMapper(cfg =>
            //{
            //    cfg.CreateMap<CreateCategoryCommand, Category>();
            //});

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetExtractQuery).GetTypeInfo().Assembly));
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            //services.AddValidatorsFromAssemblyContaining<CategoryValidation>();


            return services;
        }
    }
}
