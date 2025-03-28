using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TravelExperience.Controllers;
using TravelExperience.Models;
using TravelExperience.Services.Interfaces;
using TravelExperience.Shared;

namespace TravelExperienceTest.Controllers
{
    public class TripsControllerTests
    {
        private readonly Mock<ITripService> _tripServiceMock;
        private readonly Mock<ILogger<TripsController>> _loggerMock;
        private readonly TripsController _controller;

        public TripsControllerTests()
        {
            _tripServiceMock = new Mock<ITripService>();
            _loggerMock = new Mock<ILogger<TripsController>>();
            _controller = new TripsController(_tripServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task CreateTrip_ReturnsCreatedResult()
        {
            var trip = new Trip
            {
                TripId = 1,
                UserId = "user123",
                Title = "Trip to Paris",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(5),
                Activities = new List<Activity> { new Activity { DestinationId = 1, Duration = 2, Cost = 100 } }
            };

            _tripServiceMock.Setup(s => s.CreateTripAsync(It.IsAny<Trip>())).ReturnsAsync(trip);

            var result = await _controller.CreateTrip(trip);

            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnedTrip = Assert.IsType<Trip>(actionResult.Value);
            Assert.Equal(trip.TripId, returnedTrip.TripId);
        }

        [Fact]
        public async Task CreateTrip_ReturnsBadRequest_WhenModelIsInvalid()
        {
            _controller.ModelState.AddModelError("Title", "Title is required.");

            var trip = new Trip();

            var result = await _controller.CreateTrip(trip);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains(Constants.INVALID_TRIP_DATA, badRequestResult.Value.ToString());
        }

        [Fact]
        public async Task CreateTrip_ReturnsServerError_OnException()
        {
            var trip = new Trip { UserId = "user123", Title = "Test Trip" };

            _tripServiceMock.Setup(s => s.CreateTripAsync(It.IsAny<Trip>())).ThrowsAsync(new Exception("Test failure"));

            var result = await _controller.CreateTrip(trip);

            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Contains(Constants.SERVER_ERROR, objectResult.Value.ToString());
        }
    }
}
