using ExploreCalifornia.BusinessTier.Domain;

namespace ExploreCalifornia.BusinessTier.ExternalServices
{
    public interface IEmailService
    {
        void SendBookingConfirmationMail(Booking booking, Tour tour);
    }
}