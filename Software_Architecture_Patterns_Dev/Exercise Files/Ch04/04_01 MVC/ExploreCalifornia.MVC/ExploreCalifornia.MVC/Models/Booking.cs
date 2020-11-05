namespace ExploreCalifornia.MVC.Models
{
    public class Booking
    {
        public Tour Tour { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Transport { get; set; }
    }
}