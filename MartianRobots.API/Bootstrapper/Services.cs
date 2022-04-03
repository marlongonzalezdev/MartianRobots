using MartianRobots.API.CustomExceptionMiddleware;
using MartianRobots.Domain.Services;
using MartianRobots.Domain.Services.Abstractions;

namespace MartianRobots.API.Bootstrapper;

public static class Services
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddTransient<ExceptionMiddleware>();
    }
}
