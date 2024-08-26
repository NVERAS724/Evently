

using Evently.Modules.Events.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Application.Events;


public sealed record CreateEventCommand(
   string Title,
   string Description,
   string Location,
   DateTime StartsAtUtc,
   DateTime? EndsAtUtc) : IRequest<Guid>;
public static partial class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async (Request request, EventsDbContext context) =>
        {
            var @event = new Event
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                StartsAtUtc = request.StartsAtUtc,
                EndsAtUtc = request.EndsAtUtc,
                Status = EventStatus.Draft
            };

            context.Events.Add(@event);

            await context.SaveChangesAsync();

            return Results.Ok(@event.Id);
        })
        .WithTags(Tags.Events);
    }
}
