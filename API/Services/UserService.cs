using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class UserService : ControllerBase
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
        }

        public bool AddUser(CreateUserAccountDTO UserToAdd)
        {
            bool result = false;   // variable holds our result and initialized to false

            if (!DoesUserExist(UserToAdd.UserName))
            {
                UserModel newUser = new UserModel();  // create a new instance of our UserModel
                var newHashedPassword = HashPassword(UserToAdd.Password);
                newUser.Id = UserToAdd.Id;  // data is saved to newUser in the form of UserModel
                newUser.Username = UserToAdd.UserName;
                newUser.Salt = newHashedPassword.Salt;
                newUser.Hash = newHashedPassword.Hash;

                _context.Add(newUser);  // data added to database
                result = _context.SaveChanges() != 0;  // data saved to database as long as its not empty or unchanged
            }

            return result;
        }

        public PasswordDTO HashPassword(string password)
        {
            // new instance of our passworddto
            PasswordDTO newHashedPassword = new PasswordDTO();

            byte[] SaltBytes = new byte[64];  // create a new instance of eof byte 64 array and save to Saltbytes
            var provider = new RNGCryptoServiceProvider();   // random number generator for cryptography
            provider.GetNonZeroBytes(SaltBytes);  //removing zeros from SaltBytes
            var Salt = Convert.ToBase64String(SaltBytes);  // create a variable for our Salt and will encrypt SaltBytes
            var Rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);  // Start of Hash created here with args password as the input from our input, SaltBytes which is our salt, and # of iterations
            var Hash = Convert.ToBase64String(Rfc2898DeriveBytes.GetBytes(256));  //  encrypted string

            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;
            return newHashedPassword;
        }

        // function to verify the users password
        public bool VerifyUserPassword(string? Password, string? StoredHash, string? StoredSalt)
        {
            var SaltBytes = Convert.FromBase64String(StoredSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == StoredHash;
        }

        // function to return all users and info
        public IEnumerable<UserModel> GetAllUsers()
        {
            return _context.UserInfo;
        }

        // function to return user info by username
        public UserModel GetUserByUserName(string? username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        // Function to return server status 200 / Ok and a token for login
        public IActionResult Login(LoginDTO user)
        {
            IActionResult Result = Unauthorized();
            if (DoesUserExist(user.UserName))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("reallylongkeysuperSecretKey@345678Hello"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                Result = Ok(new { Token = tokenString });
            }
            return Result;
        }

        // Function to delete a user by using their username
        public bool DeleteUser(string userToDelete)
        {
            UserModel foundUser = GetUserByUserName(userToDelete);  // use our function made above to get our user by username
            bool result = false;  // we will be returning result and its also initialized to false
            if (foundUser != null)
            {
                foundUser.Username = userToDelete;
                _context.Remove<UserModel>(foundUser);  // 
                result = _context.SaveChanges() !=0;  //  data saved to database as long as its not empty or unchanged
            }
            return result;
        }

        // Function to get a user by user Id
        public UserModel GetUserById(int id)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Id == id);
        }

        // function to update a users info by using their id and username
        public bool UpdateUser(int id, string username)
        {
            UserModel foundUser = GetUserById(id);
            bool result = false;
            if(foundUser != null)
            {
                foundUser.Username = username;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() !=0;
            }
            return result;
        }
    }
}