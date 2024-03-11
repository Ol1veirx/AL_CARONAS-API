using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_CARONAS.Core.Entities
{
    public class Trip
    {
        public int TripId { get; set; }
        public int DriverId { get; set; }
        public string DepartureLocation { get; set; }
        public string Destination {  get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DepartureTime { get; set; }
        public int AvailabreSeats { get; set; }

    }
}
