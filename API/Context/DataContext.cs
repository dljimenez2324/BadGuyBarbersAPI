using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserModel> UserInfo { get; set; }
        public DbSet<BarberModel> BarberInfo { get; set; }
        public DbSet<BookingItemModel> BookingInfo { get; set; }
        public DbSet<ServiceItemModel> ServiceInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}