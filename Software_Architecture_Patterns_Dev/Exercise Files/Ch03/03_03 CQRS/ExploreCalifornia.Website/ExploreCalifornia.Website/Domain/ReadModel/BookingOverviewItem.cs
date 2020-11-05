namespace ExploreCalifornia.Website.Domain.ReadModel
{
    public class BookingOverviewItem
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Transport { get; set; }
        public string TourName { get; set; }
    }
}