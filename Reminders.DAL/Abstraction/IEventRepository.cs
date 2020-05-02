using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.DAL.Abstraction
{
    public interface IEventRepository
    {
        public Task<List<Event>> GetAllEventAsync();
        public Task<long> SaveAsync(Event newEvent);
        public Task<Event> FindByIdAsync(long id);
        Task<Event> UppdateAsync(Event updateEvent);
        Task DeleteAsync(Event deletedEvent);
    }
}
