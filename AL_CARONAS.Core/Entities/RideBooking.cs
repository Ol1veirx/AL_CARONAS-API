using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AL_CARONAS.Core.Enums;

namespace AL_CARONAS.Core.Entities
{
    public class RideBooking
    {
        public int RideBookingId {  get; private set; }
        public int PassagerId { get;  set; }
        public int TripId { get;  set; }
        public BookingStatus Status { get; set; }
    }
}
