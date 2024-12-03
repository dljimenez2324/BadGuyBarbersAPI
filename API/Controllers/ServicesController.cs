using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // Endpoint - Get All Services by Barbername
    }
}