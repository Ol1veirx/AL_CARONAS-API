using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Core.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AL_CARONAS.Infraestructure.Repositories.Interfaces
{
    public interface ITripRepository
    {
        Task<ICollection<Trip>> GetAllTripsAsync();
        Task<Trip> GetByIdAsync(int tripId);
        Task<Trip> CreateTripAsync(Trip trip);
        Task<Trip> UpdateTripAsync(Trip trip);
        Task<bool> DeleteTripAsync(int tripId);

    }
}
