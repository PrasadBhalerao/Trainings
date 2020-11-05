using ExploreCalifornia.Business.Bookings;

namespace ExploreCalifornia.Business.ExternalServices
{
    public interface ITravelAgentService
    {
        void NotifyTravelAgentOfBooking(Booking booking);
    }
}