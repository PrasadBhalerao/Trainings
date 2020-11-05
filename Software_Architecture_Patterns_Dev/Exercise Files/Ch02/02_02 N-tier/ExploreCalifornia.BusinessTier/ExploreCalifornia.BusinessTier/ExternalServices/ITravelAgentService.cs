using ExploreCalifornia.BusinessTier.Domain;

namespace ExploreCalifornia.BusinessTier.ExternalServices
{
    public interface ITravelAgentService
    {
        void NotifyTravelAgentOfBooking(Booking booking);
    }
}