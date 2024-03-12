using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Application.Services.Interfaces;
using AL_CARONAS.Core.Entities;
using AL_CARONAS.Infraestructure.Repositories.Interfaces;

namespace AL_CARONAS.Application.Services.Implementations
{
    public class RideBookingService : IRideBookingService
    {
        private readonly IRideBookingRepository _repository;
        public RideBookingService(IRideBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<RideBooking> CreateRideBookingAsync(RideBooking rideBooking)
        {
            return await _repository.CreateRideBookingAsync(rideBooking);
        }

        public async Task<RideBooking> UpdateRideBookingAsync(RideBooking rideBooking)
        {
            return await _repository.UpdateRideBookingAsync(rideBooking);
        }
    }
}
