using Eventify.Application.Abstractions.Services;
using Eventify.Application.DTOs;
using System.Text;

namespace Eventify.Infastructure.Services;

public class TextService : ITextService
{
    public string FormatTextForEvent(IEnumerable<EventDTO> evetItems)
    {
        if (evetItems is null)
            throw new ArgumentNullException(nameof(evetItems));

        StringBuilder builder = new();

        foreach (var eventItem in evetItems)
        {
            if (eventItem is not null)
                builder.AppendLine($"Event: {eventItem.Title} - Location: {eventItem.Location.City} - Date: {eventItem.Date.ToString("HH:mm - dd/MM/yyyy")}");
        }

        return builder.ToString().TrimEnd();
    }
}
