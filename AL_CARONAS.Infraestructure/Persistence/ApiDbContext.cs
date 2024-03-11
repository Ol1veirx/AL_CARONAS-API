using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AL_CARONAS.Infraestructure.Persistence
{
    public class ApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<RideBooking> RideBooking { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
    }
}
