using Eventify.Application.Abstractions.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Eventify.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ExportService>();
    }
}
