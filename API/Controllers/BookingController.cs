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
    public class BookingController : ControllerBase
    {
        private readonly BookingItemService _data;  // used to create a variable to hold our data
        public BookingController(BookingItemService dataFromService)  // used to assign the BookingItemService to our private variable
        {
            _data = dataFromService;
        }

        // Endpoint - To add a booking item
        [HttpPost("AddBookingItems")]
        public bool AddBookingItems(BookingItemModel newBookingItem)
        {
            return _data.AddBookingItem(newBookingItem);
        }

        // Endpoint - To Get All Booking Items
        [HttpGet("GetAllBookingItems")]
        public IEnumerable<BookingItemModel> GetAllBookingItems()
        {
            return _data.GetAllBookingItem();
        }

    }
}