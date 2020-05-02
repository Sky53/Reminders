using Reminders.Business.Abstraction;
using Reminders.DAL.Abstraction;
using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.Business.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<int> AddAsync(Event request)
        {
            var id = await _eventRepository.SaveAsync(request);
            return id;
        }

        public async Task<List<Event>> GetAllAsync()
        {
            return await _eventRepository.GetAllEvent();
        }
    }
}
