using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Core.Entities;

namespace AL_CARONAS.Application.Services.Interfaces
{
    public interface ITripService
    {
        Task<ICollection<Trip>> GetAllTripsAsync();
        Task<Trip> GetByIdAsync(int tripId);
        Task<Trip> CreateTripAsync(Trip trip);
        Task<Trip> UpdateTripAsync(Trip trip);
        Task<bool> DeleteTripAsync(int tripId);
    }
}
