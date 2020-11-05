using ExploreCalifornia.Monolith.Domain;

namespace ExploreCalifornia.Monolith.Services
{
    public interface ITravelAgentService
    {
        void NotifyTravelAgentOfBooking(Booking booking);
    }
}