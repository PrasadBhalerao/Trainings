using ExploreCalifornia.Business.ExternalServices;
using ExploreCalifornia.Business.Tours;

namespace ExploreCalifornia.Business.Bookings
{
    public class BookingsService : IBookingsService
    {
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IToursService _toursService;
        private readonly IEmailService _emailService;
        private readonly ITravelAgentService _travelAgentService;

        public BookingsService(IBookingsRepository bookingsRepository, IToursService toursService, IEmailService emailService, ITravelAgentService travelAgentService)
        {
            _bookingsRepository = bookingsRepository;
            _toursService = toursService;
            _emailService = emailService;
            _travelAgentService = travelAgentService;
        }

        public void Save(Booking booking)
        {
            _bookingsRepository.Save(booking);

            var tour = _toursService.GetTour(booking.TourId);
            _emailService.SendBookingConfirmationMail(booking, tour);
            _travelAgentService.NotifyTravelAgentOfBooking(booking);
        }
    }
}