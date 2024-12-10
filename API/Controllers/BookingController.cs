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

        // Endpoint - To Get Booking Items By Category (service type?)
        //// NEED TO CREATE HELPER FUNCTION IN SERVICES FOR THIS
        [HttpGet("GetBookingItemsByCategory/{Category}")]
        public IEnumerable<BookingItemModel> GetBookingItemsByCategory( string Category)
        {
            return _data.GetBookingItemsByCategory(Category);
        }
        
        // Endpoint - To Get Booking Items
        // [HttpGet("")]

        // Endpoint - To Get Booking Items by Date
        [HttpGet("GetBookingItemsByDate/{Date}")]
        public IEnumerable<BookingItemModel> GetBookingItemsByDate(string Date)
        {
            return _data.GetBookingItemsByDate(Date);
        }

        // // As suggested by Claude instead of the above
        // // this has an error
        // [HttpGet("GetBookingItemsByDate/{Date}")]
        // public IEnumerable<BookingItemModel> GetBookingItemsByDate(string Date)
        // {
        //     // Parse the ISO 8601 date string to a DateTime object
        //     if (!DateTime.TryParse(Date, out DateTime parsedDate))
        //     {
        //         // Return empty list or throw an exception if date parsing fails
        //         return Enumerable.Empty<BookingItemModel>();
        //     }

        //     // Filter bookings for the specific date
        //     return _data.GetBookingItemsByDate(parsedDate);
        // }

        // // This is a Psudo Delete , in other words it will do an update
        // // Endpoint - To Delete Booking Item
        // [HttpPost("DeleteBookingItem/{BookingItemToDelete}")]
        // public bool DeleteBookingItem(BookingItemModel BookingItemDelete)
        // {
        //     return _data.DeleteBookingItem(BookingItemDelete);
        // }

        //// Endpoint - to Truly Delete a Booking Item
        [HttpPost("DeleteBookingItemById/{BookingToDelete}")]
        public bool DeleteBookingById(int BookingToDelete)
        {
            return _data.DeleteBookingById(BookingToDelete);
        }
    }
}