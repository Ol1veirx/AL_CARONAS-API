using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Core.Entities;
using AL_CARONAS.Infraestructure.Persistence;
using AL_CARONAS.Infraestructure.Repositories.Interfaces;

namespace AL_CARONAS.Infraestructure.Repositories
{
    public class RideBookingRepository : IRideBookingRepository
    {
        private readonly ApiDbContext _context;
        public RideBookingRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<RideBooking> CreateRideBookingAsync(RideBooking rideBooking)
        {
            _context.RideBooking.Add(rideBooking);
            await _context.SaveChangesAsync();
            return rideBooking;
        }

        public async Task<RideBooking> UpdateRideBookingAsync(RideBooking rideBooking)
        {
            var rideBookingExisting = await _context.RideBooking.FindAsync(rideBooking.RideBookingId);

            if (rideBookingExisting == null) return null;

            rideBooking.Status = rideBooking.Status;
            await _context.SaveChangesAsync();

            return rideBookingExisting;
        }
    }
}
