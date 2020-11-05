namespace ExploreCalifornia.Website.Domain.WriteModel
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Transport { get; set; }
        public Tour Tour { get; set; }
    }
}
