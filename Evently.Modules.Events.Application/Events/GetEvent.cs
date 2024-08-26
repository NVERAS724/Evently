using Evently.Modules.Events.Domain.Events;
using MediatR;

namespace Evently.Modules.Events.Application.Events;


public sealed record GetEventQuery(Guid EventId) : IRequest<EventResponse?>;
internal sealed class GetEventQueryHandler(IEventRepository eventRepository) : IRequestHandler<GetEventQuery, EventResponse?>
{
    public async Task<EventResponse?> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        Event @event = await eventRepository.GetAsync(request.EventId);

        if(@event is null)
        {
            return null;
        }

        var eventResponse = new EventResponse(@event.Id,
            @event.Title,
            @event.Description,
            @event.Location,
            @event.StartsAtUtc,
           @event.EndsAtUtc);


        return eventResponse;
    }
}

