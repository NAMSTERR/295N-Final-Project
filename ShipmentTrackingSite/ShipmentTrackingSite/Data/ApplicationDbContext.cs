using System;
using ShipmentTrackingSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ShipmentTrackingSite.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}

