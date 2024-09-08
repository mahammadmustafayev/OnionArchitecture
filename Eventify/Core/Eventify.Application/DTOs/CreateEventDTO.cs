using Eventify.Domain.ValueObjects;

namespace Eventify.Application.DTOs;

public class CreateEventDTO
{
    public string Title { get; set; }
    public DateTimeOffset Date { get; set; }
    public Location Location { get; set; }
}
