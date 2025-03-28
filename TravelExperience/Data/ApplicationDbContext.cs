using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TravelExperience.Models;
using Activity = TravelExperience.Models.Activity;

namespace TravelExperience.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().ToTable("Activity");
            modelBuilder.Entity<Trip>().ToTable("Trip");
        }

    }
}
