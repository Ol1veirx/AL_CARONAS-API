using AL_CARONAS.Application.Services.Interfaces;
using AL_CARONAS.Core.Entities;
using AL_CARONAS_API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AL_CARONAS_API.Controllers
{
    [ApiController]
    [Route("api/trip")]
    public class TripController : Controller
    {
        private readonly ITripService _service;
        public TripController(ITripService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Trip>>> GetAllTrip()
        {
            try
            {
                var trips = await _service.GetAllTripsAsync();

                var tripsDtos = trips.Select(trips => new TripDto
                {
                    DepartureLocation = trips.DepartureLocation,
                    Destination = trips.Destination,
                    DepartureTime = trips.DepartureTime,
                    AvailabreSeats = trips.AvailabreSeats

                }); ;

                return Ok(tripsDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<Trip>> GetById(int tripId)
        {
            try
            {
                var trip = await _service.GetByIdAsync(tripId);

                return Ok(trip);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Trip>> CreateTrip(Trip trip)
        {
            try
            {
                var newTrip = await _service.CreateTripAsync(trip);

                return CreatedAtAction(nameof(GetById), new { tripId = newTrip.TripId }, newTrip);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{tripId}")]
        public async Task<ActionResult> UpdateTrip(int tripId, Trip trip)
        {
            if(tripId != trip.TripId) return NotFound();

            try
            {
                var updateTrip = await _service.UpdateTripAsync(trip);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{tripId}")]
        public async Task<ActionResult> DeleteTrip(int tripId)
        {
            try
            {
                var result = await _service.DeleteTripAsync(tripId);

                if (!result) return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
