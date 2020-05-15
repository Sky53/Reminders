using Microsoft.AspNetCore.Mvc;
using Reminders.Business.Abstraction;
using Reminders.Business.AutoMapper.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminders.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("account")]
        public async Task<IActionResult> SetUser([FromBody]UserAuthorization request)
        {
            var response = await _userService.Authorization(request);
            return Ok(response);
        }
    }
}
