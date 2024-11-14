using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ServiceItemModel
    {
        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public int ServiceDuration { get; set; } // in minutes
        public int ServicePrice { get; set; } // in dollars
        public bool ServiceSelected { get; set; } = false; // initialized as not selected
        public ServiceItemModel()
        {
            
        }
    }
}