using ExploreCalifornia.CQRSES.DataAccess;
using ExploreCalifornia.CQRSES.Domain.Events;
using ExploreCalifornia.CQRSES.Services;

namespace ExploreCalifornia.CQRSES.Domain.WriteModel.EventHandlers
{
    /// <summary>
    /// Sends a confirmation mail when a new booking has been made.
    /// </summary>
    public class BookingEmailer : IEventHandler<TourBooked>
    {
        private readonly IEmailService _emailService;
        private readonly IToursRepository _toursRepository;

        public BookingEmailer(IEmailService emailService, IToursRepository toursRepository)
        {
            _emailService = emailService;
            _toursRepository = toursRepository;
        }

        public void Handle(TourBooked e)
        {
            var tour = _toursRepository.GetTour(e.TourId);
            _emailService.SendBookingConfirmationMail(e.Email, e.Name, tour);
        }
    }
}
