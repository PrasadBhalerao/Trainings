using ExploreCalifornia.Monolith.Domain;

namespace ExploreCalifornia.Monolith.Services
{
    public interface IEmailService
    {
        void SendBookingConfirmationMail(Booking booking, Tour tour);
    }
}