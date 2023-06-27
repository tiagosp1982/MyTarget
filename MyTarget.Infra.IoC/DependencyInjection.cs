using Microsoft.Extensions.DependencyInjection;
using MyTarget.Domain.Interfaces;
using MyTarget.Infra.Data.Repositories;
using MyTarget.Application.Interfaces;
using MyTarget.Application.Services;
using MyTarget.Infra.Data.Context.Interfaces;
using MyTarget.Infra.Data.Context.Excel;
using MyTarget.Application.Commands;

namespace MyTarget.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //context
            services.AddScoped<IDataContext, DataContext>();

            //repository
            services.AddScoped<IResultDrawRepository, ResultDrawRepository>();
            services.AddScoped<IStandardStructureRepository, StandardStructureRepository>();
            services.AddScoped<IPossibilityHitRepository, PossibilityHitRepository>();
            services.AddScoped<IAmountTensBetRepository, AmountTensBetRepository>();

            //service
            services.AddScoped<IResultDrawService, ResultDrawService>();
            services.AddScoped<IStandardStructureService, StandardStructureService>();
            services.AddScoped<IAmountTensBetService, AmountTensBetService>();
            services.AddScoped<IPossibilityHitService, PossibilityHitService>();
            services.AddScoped<ITrendService, TrendService>();
            services.AddScoped<IAverageFrequencyRepetitionService, AverageFrequencyRepetitionService>();
            services.AddScoped<IDrawTotalService, DrawTotalService>();

            //command
            services.AddSingleton<ExecuteCommand, ExecuteCommand>();
            return services;
        }
    }
}
