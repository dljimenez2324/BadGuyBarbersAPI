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
    public class BarberController : ControllerBase
    {
        private readonly BarberService _data;
        
        public BarberController(BarberService dataFromService)
        {
            _data = dataFromService;
        }

        // To Add a Barber
        [HttpPost("AddBarber")]
        public bool AddBarber(CreateBarberAccountDTO BarberToAdd)
        {
            return _data.AddBarber(BarberToAdd);
        }

        // To Add Barber Services and Details
        [HttpPost("AddBarberDetails")]
        public bool AddBarberDetails(BarberModel BarberDetailsToAdd)
        {
            return _data.AddBarberDetails(BarberDetailsToAdd);
        }

        // To Get all Barbers Info
        [HttpGet("GetAllBarbersDetails")]
        public IEnumerable<BarberModel> GetAllBarbersDetails()
        {
            return _data.GetAllBarbers();
        }
    }
}