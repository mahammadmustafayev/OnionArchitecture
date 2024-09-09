using Eventify.Application.Abstractions.Services;
using Eventify.Application.Abstractions.Services.Concrete;
using Eventify.Application.DTOs;
using Eventify.Application.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace Eventify.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly ExportService _exportService;

    public EventsController(IEventService eventService, ExportService exportService)
    {
        _eventService = eventService;
        _exportService = exportService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllEventsAsync([FromQuery] Pagination pagination)
    {
        var events = await _eventService.GetAllEventsAsync(pagination);
        return Ok(events);
    }

    [HttpGet]
    public async Task<IActionResult> GetEventAsync([FromQuery] int eventId)
    {

        return Ok(await _eventService.GetEventAsync(eventId));
    }
    [HttpPost]
    public async Task<IActionResult> CreateEventAsync(CreateEventDTO eventDTO)
    {
        await _eventService.CreateEventAsync(eventDTO);

        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> UpdateEventAsync(UpdateEventDTO updateEvent)
    {
        await _eventService.UpdateEventAsync(updateEvent);
        return Ok();
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteEventAsync(int deleteId)
    {
        await _eventService.DeleteEventAsync(deleteId);
        return Ok();
    }
    [HttpPost]
    public async Task<IActionResult> ExportEvents([FromQuery] Pagination pagination, string path)
    {
        var events = await _eventService.GetAllEventsAsync(pagination);

        await _exportService.ExportEventsAsync(events, path);

        return Ok();
    }

}
