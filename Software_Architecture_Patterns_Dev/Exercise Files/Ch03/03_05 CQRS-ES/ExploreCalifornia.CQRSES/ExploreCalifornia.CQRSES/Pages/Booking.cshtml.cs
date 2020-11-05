using ExploreCalifornia.CQRSES.DataAccess;
using ExploreCalifornia.CQRSES.DataAccess.WriteModel;
using ExploreCalifornia.CQRSES.Domain;
using ExploreCalifornia.CQRSES.Domain.WriteModel.Entities;
using ExploreCalifornia.CQRSES.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ExploreCalifornia.CQRSES.Pages
{
    public class BookingModel : PageModel
    {
        private readonly IToursRepository _toursRepository;
        private readonly IEventSourcedRepository<Booking> _bookingsRepository;

        public BookingModel(IToursRepository toursRepository, IEventSourcedRepository<Booking> bookingsRepository)
        {
            _toursRepository = toursRepository;
            _bookingsRepository = bookingsRepository;
        }

        public void OnGet(int id)
        {
            Tour = _toursRepository.GetTour(id);
        }

        public IActionResult OnPost(int tourId, string name, string email, string transport)
        {
            var booking = new Booking(Guid.NewGuid(), tourId, name, email, transport == "on");
            
            _bookingsRepository.Save(booking);

            // Instead of sending a mail and calling an external API here,
            // we'll use the eventhandlers which are triggered once we
            // persist the events.

            return Redirect($"/BookingConfirmed?bookingId={booking.Id}&tourId={tourId}&name={name}&email={email}&transport={transport}");
        }

        public Tour Tour { get; private set; }
    }
}
