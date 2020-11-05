namespace ExploreCalifornia.EmailService.Contracts
{
    public class BookingConfirmationMail
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int TourId { get; set; }
    }
}