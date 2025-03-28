using TravelExperience.Models;

namespace TravelExperience.Services.Interfaces
{
    public interface ITripService
    {
        Task<Trip> CreateTripAsync(Trip trip);
    }
}
