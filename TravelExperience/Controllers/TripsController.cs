using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoulettesGame.Shared;
using TravelExperience.Models;
using TravelExperience.Services;
using TravelExperience.Services.Interfaces;

namespace TravelExperience.Controllers
{
    [Route("api/trips")]
    public class TripsController : ControllerBase
    {
        private readonly ITripService _tripService;
        private readonly ILogger<TripsController> _logger;

        public TripsController(ITripService tripService, ILogger<TripsController> logger)
        {
            _tripService = tripService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] Trip trip)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { Error = Constants.INVALID_TRIP_DATA, ModelState });

                var createdTrip = await _tripService.CreateTripAsync(trip);

                return Ok(createdTrip);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Create Trip. Mesagge:{ex.Message}, StackTrace:{ex.StackTrace}");

                return StatusCode(500, new { Error = Constants.SERVER_ERROR });
            }
        }
    }
}