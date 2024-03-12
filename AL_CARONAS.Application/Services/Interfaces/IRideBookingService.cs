using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Core.Entities;

namespace AL_CARONAS.Application.Services.Interfaces
{
    public interface IRideBookingService
    {
        Task<RideBooking> CreateRideBookingAsync(RideBooking rideBooking);
        Task<RideBooking> UpdateRideBookingAsync(RideBooking rideBooking);
    }
}
