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
    public class TripService : ITripService
    {
        private readonly ITripRepository _repository;
        public TripService(ITripRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICollection<Trip>> GetAllTripsAsync()
        {
            return await _repository.GetAllTripsAsync();
        }

        public async Task<Trip> GetByIdAsync(int tripId)
        {
            return await _repository.GetByIdAsync(tripId);
        }

        public async Task<Trip> CreateTripAsync(Trip trip)
        {
            return await _repository.CreateTripAsync(trip);
        }

        public async Task<Trip> UpdateTripAsync(Trip trip)
        {
            return await _repository.UpdateTripAsync(trip);
        }

        public async Task<bool> DeleteTripAsync(int tripId)
        {
            return await _repository.DeleteTripAsync(tripId);
        }
    }
}
