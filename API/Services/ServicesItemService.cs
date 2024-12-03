using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class ServicesItemService :ControllerBase
    {
        private readonly DataContext _context;
        public ServicesItemService(DataContext context)
        {
            _context = context;
        }

        // this is where we need to have functions for getting barber services
    }
}