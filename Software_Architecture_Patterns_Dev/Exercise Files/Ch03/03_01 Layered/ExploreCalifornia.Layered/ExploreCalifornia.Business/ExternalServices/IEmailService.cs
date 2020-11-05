using ExploreCalifornia.Business.Bookings;
using ExploreCalifornia.Business.Tours;

namespace ExploreCalifornia.Business.ExternalServices
{
    public interface IEmailService
    {
        void SendBookingConfirmationMail(Booking booking, Tour tour);
    }
}