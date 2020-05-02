using AutoMapper;
using Reminders.Business.Abstraction;
using Reminders.Business.AutoMapper.Event;
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
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<long> AddAsync(EventRequest request)
        {
            var newEvent = _mapper.Map<Event>(request);
            newEvent.CreatedDate = DateTime.Now;
            var id = await _eventRepository.SaveAsync(newEvent);

            return id;
        }

        public async Task DeleteAsync(long id)
        {
            var deletedEvent = await _eventRepository.FindByIdAsync(id);
            deletedEvent.isDeleted = true;

            await _eventRepository.DeleteAsync(deletedEvent);
        }

        public async Task<List<EventResponse>> GetAllAsync()
        {
            var events = await _eventRepository.GetAllEventAsync();
            return _mapper.Map<List<EventResponse>>(events);
        }

        public async Task<EventResponse> UpdateAsync(long id, EventRequest updateEvent)
        {
            var currentEvents = await _eventRepository.FindByIdAsync(id);
            
            var newEvent = _mapper.Map<Event>(updateEvent);
            newEvent.Id = id;
            newEvent.CreatedDate = currentEvents.CreatedDate;
            await _eventRepository.UppdateAsync(newEvent);

           return _mapper.Map<EventResponse>(newEvent);
        }
    }
}
