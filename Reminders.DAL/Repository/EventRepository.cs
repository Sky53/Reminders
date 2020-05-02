using Microsoft.EntityFrameworkCore;
using Reminders.DAL.Abstraction;
using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
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
        public async Task<List<Event>> GetAllEvent()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<int> SaveAsync(Event newEvent)
        {
            if (newEvent == null)
            {
                throw new Exception("received an empty product");
            }

            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            return newEvent.Id;
        }
    }
}
