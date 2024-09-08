using Eventify.Application.Abstractions.Services;
using Eventify.Infastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Eventify.Infastructure;

public static class ServiceRegistration
{
    public static void AddInfastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ITextService, TextService>();
    }
}
