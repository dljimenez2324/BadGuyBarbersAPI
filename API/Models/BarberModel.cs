using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class BarberModel
    {
        public int Id { get; set; }
        public string? Username { get; set;}
        public string? BarberName { get; set; }
        public string? DaysAvailable { get; set; }
        public string? TimesAvailable { get; set; }
        public bool[]? TimeAvailableBool { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        public BarberModel()
        {
            
        }
    }
}