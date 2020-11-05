namespace ExploreCalifornia.PresentationTier.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Transport { get; set; }
        public int TourId { get; set; }
    }
}
