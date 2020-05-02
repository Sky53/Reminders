using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.Business.Abstraction
{
    public interface IEventService
    {
        public Task<List<Event>> GetAllAsync();
        public Task<int> AddAsync(Event request);
    }
}
