using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
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
        
        // To Add a User
        [HttpPost("AddUser")]
        public bool AddUser(CreateUserAccountDTO UserToAdd)
        {
            return _data.AddUser(UserToAdd);
        }

        // To Get All Users
        [HttpGet("GetAllUsers")]
        public IEnumerable<UserModel> GetAllUsers ()
        {
            return _data.GetAllUsers();
        }

        // Login for User
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }
    }
}