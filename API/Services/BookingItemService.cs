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

        public IEnumerable<BookingItemModel> GetBookingItemsByCategory(string category)
        {
            return _context.BookingInfo.Where(item => item.ServiceCategory == category);
        }

        // Service to find booking items by a date string
        public IEnumerable<BookingItemModel> GetBookingItemsByDate(string date)
        {
            // Extract just the date part, ignoring time and return items by given date
            var bookingItems = _context.BookingInfo;
            List<BookingItemModel> result = new();
            foreach(BookingItemModel item in bookingItems) 
            {
                
                if (item.DateTimeTaken.Split(' ')[0] == date)
                {
                    result.Add(item);
                }

            }
            
            return result;
                
        }


        //// Helper function to get a booking by id
        private BookingItemModel GetBookingById(int bookingToDelete)
        {
            return _context.BookingInfo.SingleOrDefault(item => item.Id == bookingToDelete);
        }
        public bool DeleteBookingById(int bookingToDelete)
        {
            // send over our booking id to to find/fetch the booking item
            BookingItemModel foundBookingItem = GetBookingById(bookingToDelete);
            bool result = false;
            if (foundBookingItem !=null)
            {
                foundBookingItem.Id = bookingToDelete;
                _context.Remove<BookingItemModel>(foundBookingItem);
                result = _context.SaveChanges() !=0;
            }
            return result;
        }

        //// This delete is actually an update to render the item "inactive" i assume.
        // public bool DeleteBookingItem(BookingItemModel bookingItemDelete)
        // {
        //     _context.Update<BookingItemModel>(bookingItemDelete);
        //     return _context.SaveChanges() !=0;
        // }
    }
}