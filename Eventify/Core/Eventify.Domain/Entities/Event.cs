using Eventify.Domain.Common;
using Eventify.Domain.ValueObjects;

namespace Eventify.Domain.Entities;

public class Event : BaseEntity
{

    public string Title { get; set; }
    public DateTimeOffset Date { get; set; }
    public Location Location { get; set; }
}
