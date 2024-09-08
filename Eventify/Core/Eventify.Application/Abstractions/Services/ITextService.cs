using Eventify.Application.DTOs;

namespace Eventify.Application.Abstractions.Services;

public interface ITextService
{
    string FormatTextForEvent(IEnumerable<EventDTO> evetItems);
}
