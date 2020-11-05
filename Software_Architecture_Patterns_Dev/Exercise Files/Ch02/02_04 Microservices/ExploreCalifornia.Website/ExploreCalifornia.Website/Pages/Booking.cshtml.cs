using ExploreCalifornia.Website.ExternalServices;
using ExploreCalifornia.Website.ExternalServices.Bookings;
using ExploreCalifornia.Website.ExternalServices.Tours;
using ExploreCalifornia.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Website.Pages
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
            var booking = new Models.Booking
            {
                TourId = tourId,
                Name = name,
                Email = email,
                Transport = transport == "on"
            };

            _bookingsProxy.Save(booking);

            return Redirect($"/BookingConfirmed?tourId={tourId}&name={name}&email={email}&transport={transport}");
        }

        public Models.Tour Tour { get; private set; }
    }
}
