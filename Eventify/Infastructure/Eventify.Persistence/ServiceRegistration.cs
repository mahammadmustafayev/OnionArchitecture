using Eventify.Application.Abstractions.Services;
using Eventify.Persistence.DataAccess;
using Eventify.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Eventify.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<IEventService, EventService>();
        services.AddDbContext<AppDbContext>();
    }
}
