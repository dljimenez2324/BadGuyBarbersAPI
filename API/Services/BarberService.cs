using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class BarberService : ControllerBase
    {
        private readonly DataContext _context;
        public BarberService(DataContext context)
        {
            _context = context;
        }

        // check to see if barber username exists
        public bool DoesUserExist(string username)
        {
            return _context.BarberInfo.SingleOrDefault(barber => barber.Username == username) !=null;
        }

        // to add a new barber to the server
        public bool AddBarber(CreateBarberAccountDTO BarberToAdd)
        {
            bool result = false;
            if(!DoesUserExist(BarberToAdd.UserName))
            {
                BarberModel newBarber = new BarberModel();
                var newHashedPassword = HashPassword(BarberToAdd.Password);
                newBarber.Id = BarberToAdd.Id;
                newBarber.Username = BarberToAdd.UserName;
                newBarber.Salt = newHashedPassword.Salt;
                newBarber.Hash = newHashedPassword.Hash;

                _context.Add(newBarber);
                result = _context.SaveChanges() !=0;
            }
            return result;
        }

        // to hash the password of the new barber
        public PasswordDTO HashPassword(string password)
        {
            PasswordDTO newHashedPassword = new PasswordDTO();

            byte[] SaltBytes = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(SaltBytes);
            var Salt = Convert.ToBase64String(SaltBytes);
            var Rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);
            var Hash = Convert.ToBase64String(Rfc2898DeriveBytes.GetBytes(256));

            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;
            return newHashedPassword;

        }

        //  function to verify the barbers password
        public bool VerifyBarberPassword(string? Password, string? StoredHash, string? StoredSalt)
        {
            var SaltBytes = Convert.FromBase64String(StoredSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == StoredHash;
        }

        // function to return all barbers info
        public IEnumerable<BarberModel> GetAllBarbers()
        {
            return _context.BarberInfo;
        }

        // function to return barber info by username
        public BarberModel GetBarberByUserName(string? username)
        {
            return _context.BarberInfo.SingleOrDefault(barber => barber.Username == username);
        }

        public bool AddBarberDetails(BarberModel barberDetailsToAdd)
        {
            bool result = false;

            // Because we already have a user added checking to see if the user exists means we will exit out of the if below and we'll never add barber details so we must not use that for now
            // if(!DoesUserExist(barberDetailsToAdd.Username))
            // {
            //     BarberModel newBarber = new BarberModel();
            //     newBarber.
            // }

            BarberModel newBarber = new BarberModel();
            newBarber.Id = barberDetailsToAdd.Id;
            newBarber.Username = barberDetailsToAdd.Username;
            newBarber.BarberName = barberDetailsToAdd.BarberName;
            newBarber.DaysAvailable = barberDetailsToAdd.DaysAvailable;
            newBarber.TimesAvailable = barberDetailsToAdd.TimesAvailable;
            newBarber.TimeAvailableBool = barberDetailsToAdd.TimeAvailableBool;

            _context.Add(newBarber);
            result = _context.SaveChanges() !=0;

            return result;
        }


    }
}