using Microsoft.EntityFrameworkCore;
using Reminders.DAL.Abstraction;
using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.DAL.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly RemindersContext _context;

        public EventRepository(RemindersContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllEventAsync()
        {
            var allEvents = await _context.Events.ToListAsync();
            return allEvents.Where(ev => ev.isDeleted == false).ToList();
        }

        public async Task<Event> FindByIdAsync(long id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<long> SaveAsync(Event newEvent)
        {
            if (newEvent == null)
            {
                throw new Exception("received an empty evant");
            }

            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            return newEvent.Id;
        }

        public async Task<Event> UppdateAsync(Event upadateEvent)
        {
            _context.Events.Update(upadateEvent);
            await _context.SaveChangesAsync();

            return upadateEvent;
        }

        public async Task DeleteAsync(Event deletedEvent)
        {
            _context.Events.Update(deletedEvent);
            await _context.SaveChangesAsync();
        }
    }
}
