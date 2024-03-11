namespace AL_CARONAS_API.DTOs
{
    public class TripDto
    {
        public string DepartureLocation { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailabreSeats { get; set; }
    }
}
