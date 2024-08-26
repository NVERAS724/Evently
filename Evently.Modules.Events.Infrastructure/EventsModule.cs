


using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Application.Events;
using Evently.Modules.Events.Infrastructure.Database;
using Evently.Modules.Events.Infrastructure.Events;
using Evently.Modules.Events.Presentation.Events;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evently.Modules.Events.Infrastructure;
public static class EventsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        EventEndpoints.MapEndpoints(app);
    }

    public static IServiceCollection AddEventsModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<EventsDbContext>(options =>
                    options
                        .UseNpgsql(databaseConnectionString,
                                    npgslOptions => 
                                            npgslOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events)
                ));

        services.AddScoped<IEventRepository, EventRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbContext>());

        return services;
    }
}
