using Reminders.Business.AutoMapper.Event;
using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.Business.Abstraction
{
    public interface IEventService
    {
        public Task<List<EventResponse>> GetAllAsync();
        public Task<long> AddAsync(EventRequest request);
        public Task<EventResponse> UpdateAsync(long id, EventRequest updateEvent);
        public Task DeleteAsync(long id);
    }
}
