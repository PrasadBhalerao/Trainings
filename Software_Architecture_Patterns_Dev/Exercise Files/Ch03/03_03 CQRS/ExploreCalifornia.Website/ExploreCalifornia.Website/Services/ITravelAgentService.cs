using ExploreCalifornia.Website.Domain;
using ExploreCalifornia.Website.Domain.WriteModel;

namespace ExploreCalifornia.Website.Services
{
    public interface ITravelAgentService
    {
        void NotifyTravelAgentOfBooking(Booking booking);
    }
}
