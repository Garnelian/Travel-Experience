using Microsoft.EntityFrameworkCore;
using TravelExperience.Data.Repositories.Interfaces;
using TravelExperience.Models;

namespace TravelExperience.Data.Repositories
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Trip> AddTripAsync(Trip trip)
        {
            trip.TotalCost = trip.Activities.Sum(a => a.Cost);
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
            return trip;
        }
    }
}
