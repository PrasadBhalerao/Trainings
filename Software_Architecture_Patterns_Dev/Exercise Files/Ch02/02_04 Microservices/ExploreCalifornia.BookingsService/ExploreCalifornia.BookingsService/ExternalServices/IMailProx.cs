using ExploreCalifornia.BookingsService.Domain;

namespace ExploreCalifornia.BookingsService.ExternalServices
{
    public interface IMailProxy
    {
        void SendMail(Booking booking);
    }
}