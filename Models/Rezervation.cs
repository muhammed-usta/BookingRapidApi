namespace BookingRapidApi.Models
{
    public class Rezervation
    {
        public int RezervationId { get; set; }
        public string City { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int RoomCount { get; set; }
        public int GuestCount { get; set; }
    }
}
