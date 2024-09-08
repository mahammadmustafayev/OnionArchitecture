using Eventify.Domain.ValueObjects;

namespace Eventify.Application.DTOs;

public class UpdateEventDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTimeOffset Date { get; set; }
    public Location Location { get; set; }
}
