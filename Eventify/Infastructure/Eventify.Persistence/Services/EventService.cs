﻿using Eventify.Application.Abstractions.Services;
using Eventify.Application.DTOs;
using Eventify.Application.RequestParameters;
using Eventify.Domain.Entities;
using Eventify.Persistence.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Eventify.Persistence.Services;

public class EventService : IEventService
{

    private readonly AppDbContext _context;

    public EventService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateEventAsync(CreateEventDTO createEventDTO)
    {
        if (createEventDTO is not null)
        {
            var newevent = new Event()
            {
                Title = createEventDTO.Title,
                Date = createEventDTO.Date,
                Location = createEventDTO.Location,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await _context.Events.AddAsync(newevent);
            await _context.SaveChangesAsync();
        }
        else
            throw new NullReferenceException();

    }

    public async Task DeleteEventAsync(int deleteId)
    {
        if (deleteId != null)
        {
            var result = await _context.Events.FindAsync(deleteId);
            _context.Events.Remove(result);
            await _context.SaveChangesAsync();
        }
        else
            throw new NullReferenceException();
    }

    public async Task<IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination)
    {
        return await _context.Events
            .AsNoTracking()
            .Select(x => new EventDTO()
            {
                Title = x.Title,
                Date = x.Date,
                Location = x.Location
            })
            .Skip(pagination.PageCount * pagination.ItemCount)
            .Take(pagination.ItemCount)
            .ToListAsync();
    }

    public async Task<Event> GetEventAsync(int eventId)
    {
        return await _context.Events.FirstOrDefaultAsync(x => x.Id == eventId);


    }

    public async Task UpdateEventAsync(UpdateEventDTO updateEventDTO)
    {
        if (updateEventDTO is not null)
        {
            Event updateDTO = await _context.Events.FirstOrDefaultAsync(x => x.Id == updateEventDTO.Id);
            updateDTO.Title = updateEventDTO.Title;
            updateDTO.Date = updateEventDTO.Date;
            updateDTO.Location = updateEventDTO.Location;
            updateDTO.UpdatedDate = DateTimeOffset.UtcNow;
            _context.Events.Update(updateDTO);
            await _context.SaveChangesAsync();

        }
        else
            throw new NullReferenceException();
    }
}
