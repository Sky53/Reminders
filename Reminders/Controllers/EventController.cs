using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reminders.Business.Abstraction;
using Reminders.Business.AutoMapper.Event;
using Reminders.Domain.Models;

namespace Reminders.API.Controllers
{
    [ApiController]
    [Route("api/event")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/event/get-events
        [HttpGet]
        [Route("get-events")]
        public async Task<IActionResult> GetEvents()
        {
            return Ok(await _eventService.GetAllAsync());
        }


        // POST: api/event/creat-events
        [HttpPost]
        [Route("creat-events")]
        public async Task<IActionResult> SetEvent([FromBody]EventRequest request)
        {
            var response = await _eventService.AddAsync(request);
            return Ok(response);
        }

        // PUT: api/event/update-events
        [HttpPut]
        [Route("update-events/{id}")]
        public async Task<IActionResult> UpdateEvent([FromBody]EventRequest request, long id)
        {
            var response = await _eventService.UpdateAsync(id, request);
            return Ok(response);
        }

        // Delete: api/event/delete-events
        [HttpDelete]
        [Route("delete-events/{id}")]
        public async Task<IActionResult> DeleteEvent(long id)
        {
            await _eventService.DeleteAsync(id);
            return Ok();
        }
    }
}
