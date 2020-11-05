namespace ExploreCalifornia.BookingsService.ESB.Contracts
{
    public class BookingMade
    {
        public int TourId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool Transport { get; set; }
    }
}