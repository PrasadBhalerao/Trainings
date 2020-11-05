using ExploreCalifornia.BookingsService.Domain;

namespace ExploreCalifornia.BookingsService.ESB
{
    public interface IESBroxy
    {
        void NotifyBookingMade(Booking booking);
    }
}