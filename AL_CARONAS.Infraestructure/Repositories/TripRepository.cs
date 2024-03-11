using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Core.Entities;
using AL_CARONAS.Infraestructure.Persistence;
using AL_CARONAS.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AL_CARONAS.Infraestructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ApiDbContext _context;
        public TripRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Trip>> GetAllTripsAsync()
        {
            return await _context.Trips.ToListAsync();
        }

        public async Task<Trip> GetByIdAsync(int tripId)
        {
            var trip = await _context.Trips.FindAsync(tripId);

            if (trip == null) return null;

            return trip;
        }

        public async Task<Trip> CreateTripAsync(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
            return trip;
        }

        public async Task<Trip> UpdateTripAsync(Trip trip)
        {
            var updateTrip = await _context.Trips.FindAsync(trip.TripId);

            if (updateTrip == null) return null;

            updateTrip.Destination = trip.Destination;
            updateTrip.DepartureLocation = trip.DepartureLocation;
            updateTrip.DepartureTime = trip.DepartureTime;
            updateTrip.AvailabreSeats = trip.AvailabreSeats;

            await _context.SaveChangesAsync();

            return updateTrip;

        }

        public async Task<bool> DeleteTripAsync(int tripId)
        {
            var result = await _context.Trips.FindAsync(tripId);

            if (result == null) return false;

            _context.Trips.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
