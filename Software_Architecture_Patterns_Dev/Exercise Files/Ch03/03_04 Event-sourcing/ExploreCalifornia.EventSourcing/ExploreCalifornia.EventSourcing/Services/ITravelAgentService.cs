using ExploreCalifornia.EventSourcing.Domain.Entities;

namespace ExploreCalifornia.EventSourcing.Services
{
    public interface ITravelAgentService
    {
        void NotifyTravelAgentOfBooking(string email, string name, int tourId);
        void NotifyTravelAgentOfCancellation(string email, string name, int tourId, string cancellationReason);
    }
}
