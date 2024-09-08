using Eventify.Domain.ValueObjects;

namespace Eventify.Application.DTOs;

public class EventDTO
{
    public string Title { get; set; }
    public DateTimeOffset Date { get; set; }
    public Location Location { get; set; }
}
