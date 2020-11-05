using ExploreCalifornia.EventSourcing.Domain.Events;
using ExploreCalifornia.EventSourcing.Services;

namespace ExploreCalifornia.EventSourcing.Domain.EventHandlers
{
    /// <summary>
    /// This eventhandler notifies the travel agent when a tour has been booked or canceled.
    /// </summary>
    public class TravelAgentNotifier : IEventHandler<TourBooked>, IEventHandler<BookingCanceled>
    {
        private readonly ITravelAgentService _travelAgentService;

        public TravelAgentNotifier(ITravelAgentService travelAgentService)
        {
            _travelAgentService = travelAgentService;
        }

        public void Handle(TourBooked e)
        {
            _travelAgentService.NotifyTravelAgentOfBooking(
                e.Email, e.Name, e.TourId);
        }

        public void Handle(BookingCanceled e)
        {
            _travelAgentService.NotifyTravelAgentOfCancellation(e.Email, e.Name, e.TourId, e.Reason);
        }
    }
}
