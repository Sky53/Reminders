using Microsoft.AspNetCore.Mvc;
using Reminders.Business.Abstraction;
using Reminders.Business.AutoMapper.User;
using Reminders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminders.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users/get-users
        [HttpGet]
        [Route("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetAllAsync());
        }


        // POST: api/users/creat-user
        [HttpPost]
        [Route("creat-user")]
        public async Task<IActionResult> SetUser([FromBody]UserRequest request)
        {
            var response = await _userService.AddAsync(request);
            return Ok(response);
        }

        // PUT: api/users/update-user
        [HttpPut]
        [Route("update-user/{id}")]
        public async Task<IActionResult> UpdateUser([FromBody]UserRequest request, long id)
        {
            var response = await _userService.UpdateAsync(id, request);
            return Ok(response);
        }

        // Delete: api/users/delete-user
        [HttpDelete]
        [Route("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
