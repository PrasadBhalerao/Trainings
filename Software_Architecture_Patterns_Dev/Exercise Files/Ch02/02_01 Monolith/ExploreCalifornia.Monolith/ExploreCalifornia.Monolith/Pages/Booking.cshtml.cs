using ExploreCalifornia.Monolith.DataAccess;
using ExploreCalifornia.Monolith.Domain;
using ExploreCalifornia.Monolith.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Monolith.Pages
{
    public class BookingModel : PageModel
    {
        private readonly IToursRepository _toursRepository;
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IEmailService _emailService;
        private readonly ITravelAgentService _travelAgentService;

        public BookingModel(IToursRepository toursRepository, IBookingsRepository bookingsRepository, IEmailService emailService, ITravelAgentService travelAgentService)
        {
            _toursRepository = toursRepository;
            _bookingsRepository = bookingsRepository;
            _emailService = emailService;
            _travelAgentService = travelAgentService;
        }

        public void OnGet(int id)
        {
            Tour = _toursRepository.GetTour(id);
        }

        public IActionResult OnPost(int tourId, string name, string email, string transport)
        {
            var booking = new Booking
            {
                TourId = tourId,
                Name = name,
                Email = email,
                Transport = transport == "on"
            };

            var tour = _toursRepository.GetTour(tourId);
            _bookingsRepository.Save(booking);
            _emailService.SendBookingConfirmationMail(booking, tour);
            _travelAgentService.NotifyTravelAgentOfBooking(booking);

            return Redirect($"/BookingConfirmed?tourId={tourId}&name={name}&email={email}&transport={transport}");
        }

        public Tour Tour { get; private set; }
    }
}
