using ExploreCalifornia.PresentationTier.Business;
using ExploreCalifornia.PresentationTier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.PresentationTier.Pages
{
    public class BookingModel : PageModel
    {
        private readonly IToursProxy _toursProxy;
        private readonly IBookingsProxy _bookingsProxy;

        public BookingModel(IToursProxy toursProxy, IBookingsProxy bookingsProxy)
        {
            _toursProxy = toursProxy;
            _bookingsProxy = bookingsProxy;
        }

        public void OnGet(int id)
        {
            Tour = _toursProxy.GetTour(id);
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

            var tour = _toursProxy.GetTour(tourId);
            _bookingsProxy.Save(booking);

            return Redirect($"/BookingConfirmed?tourId={tourId}&name={name}&email={email}&transport={transport}");
        }

        public Tour Tour { get; private set; }
    }
}
