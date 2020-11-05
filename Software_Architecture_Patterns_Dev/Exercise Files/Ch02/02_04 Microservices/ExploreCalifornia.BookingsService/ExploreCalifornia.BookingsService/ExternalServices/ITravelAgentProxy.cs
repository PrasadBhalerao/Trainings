using ExploreCalifornia.BookingsService.Domain;

namespace ExploreCalifornia.BookingsService.ExternalServices
{
    public interface ITravelAgentProxy
    {
        void NotifyTravelAgent(Booking booking);
    }
}