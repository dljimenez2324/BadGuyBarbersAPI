using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using API.Models.DTO;

namespace API.Services
{
    public class UserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username) !=null;
        }
        public bool AddUser(CreateUserAccountDTO UserToAdd)
        {
            bool result = false;

            if(DoesUserExist(UserToAdd.UserName))
            {
                UserModel User = new UserModel();
            }

            return result;
        }
        // public PasswordDTO HashPassword(string password)
        // {

        // }
    }
}