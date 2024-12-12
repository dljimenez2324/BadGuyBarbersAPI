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

        // To Get a single Users userID and userName by username using DTO
        [HttpGet("GetUserByUserName/{username}")]
        public UserIdDTO GetUserIdDTOByUserName(string username)
        {
            return _data.GetUserIdDTOByUserName(username);
        }

        // Login for User
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }

        // Delete User Account
        [HttpPost("DeleteUser/{userToDelete}")]
        public bool DeleteUser(string userToDelete)
        {
            return _data.DeleteUser(userToDelete);
        }

        // Update User Accounts Username by giving the id and the username that will be changed to
        [HttpPost("UpdateUser")]
        public bool UpdateUser(int id, string username)
        {
            return _data.UpdateUser(id,username);
        }
    }
}