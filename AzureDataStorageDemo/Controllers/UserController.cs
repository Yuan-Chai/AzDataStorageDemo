using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AzureDataStorageDemo.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureDataStorageDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateUserModel createUser)
        {
            await _userService.Create(createUser);
            return Accepted();
        }

    }
}