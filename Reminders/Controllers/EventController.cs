using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reminders.Business.Abstraction;
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
        public async Task<IActionResult> SetEvent([FromBody]Event request)
        {
            var response = await _eventService.AddAsync(request);
            return Ok(response);
        }
    }
}
