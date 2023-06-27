using Microsoft.Extensions.DependencyInjection;
using MyTarget.Application.Commands;
using MyTarget.Application.Interfaces;
using MyTarget.Application.Services;
using MyTarget.Infra.IoC;

namespace MyTarget.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<ExecuteCommand>().Execute();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();
        }
    }
}