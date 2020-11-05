namespace ExploreCalifornia.ESB.Contracts.Bookings
{
    public class CreateBookingRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Transport { get; set; }
        public int TourId { get; set; }
    }
}