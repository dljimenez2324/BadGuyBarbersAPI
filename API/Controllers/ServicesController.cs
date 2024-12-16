using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ServicesItemService _data;
        public ServicesController(ServicesItemService dataFromService)
        {
            _data = dataFromService;
        }

        //  Create endpoints for frontend to get services offered by the Barbers

        // Endpoint - To Add Services to a barbers id / username
        [HttpPost("AddServicesToBarber")]
        public bool AddServicesToBarber(ServiceItemModel newServiceItem)
        {
            return _data.AddServicesToBarber(newServiceItem);
        }

        // Endpoint - Get All Services
        [HttpGet("GetAllBarberServices")]
        public IEnumerable<ServiceItemModel> GetAllBarberServices()
        {
            return _data.GetAllBarberServices();
        }
    }
}