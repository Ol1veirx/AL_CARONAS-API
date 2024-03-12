using AL_CARONAS.Application.Services.Interfaces;
using AL_CARONAS.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AL_CARONAS_API.Controllers
{
    [ApiController]
    [Route("api/ridebooking")]
    public class RideBookingController : Controller
    {
        private readonly IRideBookingService _service;
        public RideBookingController(IRideBookingService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<RideBooking>> CreateRideBooking(RideBooking rideBooking)
        {
            try
            {
                var newRideBooking = await _service.CreateRideBookingAsync(rideBooking);

                if (newRideBooking == null) return NotFound();

                return Ok(newRideBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{rideBookingId}")]
        public async Task<ActionResult<RideBooking>> UpdateRideBooking(int rideBookingId,RideBooking rideBooking)
        {
            if (rideBookingId != rideBooking.RideBookingId) return NotFound();

            try
            {
                var updateRideBooking = await _service.UpdateRideBookingAsync(rideBooking);

                if (updateRideBooking == null) return BadRequest();

                return updateRideBooking;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
