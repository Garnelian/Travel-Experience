using TravelExperience.Models;

namespace TravelExperience.Data.Repositories.Interfaces
{
    public interface ITripRepository
    {
        Task<Trip> AddTripAsync(Trip trip);
    }
}
