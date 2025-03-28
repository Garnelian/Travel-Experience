using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoulettesGame.Shared;
using TravelExperience.Models;
using TravelExperience.Services;

namespace TravelExperience.Controllers
{
    [Route("api/trips")]
    public class TripsController : ControllerBase
    {
        private readonly TripService _tripService;
        private readonly ILogger<TripsController> _logger;

        public TripsController(TripService tripService, ILogger<TripsController> logger) {
            _tripService = tripService;
            _logger= logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] Trip trip)
        {
            try
            {
                if (trip == null || !trip.Activities.Any()) return BadRequest(Constants.INVALID_TRIP_DATA);

                var createdTrip = await _tripService.CreateTripAsync(trip);

                return Ok(trip);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error placing bet. Mesagge:{ex.Message}, StackTrace:{ex.StackTrace}");

                return StatusCode(500, new { Error = Constants.SERVER_ERROR });
            }
        }
    }
}