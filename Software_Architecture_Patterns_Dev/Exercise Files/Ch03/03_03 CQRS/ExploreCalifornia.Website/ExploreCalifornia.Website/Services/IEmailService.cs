using ExploreCalifornia.Website.Domain;
using ExploreCalifornia.Website.Domain.WriteModel;

namespace ExploreCalifornia.Website.Services
{
    public interface IEmailService
    {
        void SendBookingConfirmationMail(Booking booking, Tour tour);
    }
}
