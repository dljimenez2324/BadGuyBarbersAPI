using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class BookingItemService : ControllerBase
    {
        private readonly DataContext _context;  // variable to hold our data
        public BookingItemService(DataContext context)
        {
            _context = context; 
        }
        public bool AddBookingItem(BookingItemModel newBookingItem)
        {
            bool result = false; // variable to hold result and initialze to false
            _context.Add(newBookingItem);

            result = _context.SaveChanges() !=0;  // data saved to database only if its not empty or ...
            return result;
        }

        public IEnumerable<BookingItemModel> GetAllBookingItem()
        {
            return _context.BookingInfo;
        }
    }
}