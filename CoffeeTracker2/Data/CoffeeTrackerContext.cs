using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoffeeTracker.Models;

namespace CoffeeTracker.Models
{
    public class CoffeeTrackerContext : DbContext
    {
        public CoffeeTrackerContext (DbContextOptions<CoffeeTrackerContext> options)
            : base(options)
        {
        }
        public DbSet<CoffeeTracker.Models.CoffeeItems> CoffeeItems { get; set; }
        public DbSet<CoffeeTracker.Models.UserProfile> UserProfile { get; set; }
     
      
    }
}
