using TravelExperience.Data.UnitOfWork;
using TravelExperience.Models;
using TravelExperience.Services.Interfaces;

namespace TravelExperience.Services
{
    public class TripService : ITripService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TripService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public async Task<Trip> CreateTripAsync(Trip trip)
        {
            await _unitOfWork.CompleteAsync();

            return await _unitOfWork.TripRepository.AddTripAsync(trip);
        }
    }
}
