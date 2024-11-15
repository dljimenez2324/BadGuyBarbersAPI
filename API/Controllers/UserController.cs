using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.DTO;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;

        public UserController(UserService dataFromService)
        {
            _data = dataFromService;
        }
        
        // to add a User
        [HttpPost("AddUser")]
        public bool AddUser(CreateUserAccountDTO UserToAdd)
        {
            return _data.AddUser(UserToAdd);
        }
    }
}