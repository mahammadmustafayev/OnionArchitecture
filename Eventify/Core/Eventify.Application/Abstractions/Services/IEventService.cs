using Eventify.Application.DTOs;
using Eventify.Application.RequestParameters;
using Eventify.Domain.Entities;

namespace Eventify.Application.Abstractions.Services;

public interface IEventService
{
    Task<IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination);
    Task<Event> GetEventAsync(int eventId);
    Task CreateEventAsync(CreateEventDTO createEventDTO);

    Task UpdateEventAsync(UpdateEventDTO updateEventDTO);

    Task DeleteEventAsync(int deleteId);
}
