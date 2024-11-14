using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class BookingItemModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BarberId { get; set; }
        public string? BarberName { get; set; }
        public string? BarberService { get; set; }
        public string? DateTimeTaken { get; set; }
        public int ServicePrice { get; set; }
        public int ServiceDuration { get; set; }
        public string? ServiceCategory { get; set; }
        public BookingItemModel()
        {
            
        }
    }
}