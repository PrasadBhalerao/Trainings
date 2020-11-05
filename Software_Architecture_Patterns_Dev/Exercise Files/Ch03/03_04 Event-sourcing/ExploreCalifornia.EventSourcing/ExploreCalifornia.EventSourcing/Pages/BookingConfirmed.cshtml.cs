using ExploreCalifornia.EventSourcing.DataAccess;
using ExploreCalifornia.EventSourcing.Domain;
using ExploreCalifornia.EventSourcing.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ExploreCalifornia.EventSourcing.Pages
{
    public class BookingConfirmedModel : PageModel
    {
        private readonly IToursRepository _toursRepository;
        private readonly IEventSourcedRepository<Booking> _bookingsRepository;

        public Tour Tour { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Transport { get; private set; }
        public Guid BookingId { get; private set; }

        public BookingConfirmedModel(IToursRepository toursRepository, IEventSourcedRepository<Booking> bookingRepository)
        {
            _toursRepository = toursRepository;
            _bookingsRepository = bookingRepository;
        }

        public void OnGet(Guid bookingId, int tourId, string name, string email, string transport)
        {
            BookingId = bookingId;
            Tour = _toursRepository.GetTour(tourId);
            Name = name;
            Email = email;
            Transport = transport == "on";
        }

        public IActionResult OnPost(Guid bookingId, string reason, string tourname, string name)
        {
            var booking = _bookingsRepository.Get(bookingId);
            booking.Cancel(reason);

            _bookingsRepository.Save(booking);

            return Redirect($"/BookingCanceled?tourname={tourname}&name={name}");
        }
    }
}
