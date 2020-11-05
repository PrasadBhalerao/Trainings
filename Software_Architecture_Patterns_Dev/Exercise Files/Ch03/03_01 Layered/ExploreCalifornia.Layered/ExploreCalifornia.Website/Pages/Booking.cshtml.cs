using ExploreCalifornia.Application.Bookings;
using ExploreCalifornia.Application.Tours;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Website.Pages
{
    public class BookingModel : PageModel
    {
        private readonly ToursController _toursController;
        private readonly BookingsController _bookingsController;

        public BookingModel(ToursController toursController, BookingsController bookingsController)
        {
            _toursController = toursController;
            _bookingsController = bookingsController;
        }

        public void OnGet(int id)
        {
            Tour = _toursController.GetTour(id);
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

            _bookingsController.Save(booking);

            return Redirect($"/BookingConfirmed?tourId={tourId}&name={name}&email={email}&transport={transport}");
        }

        public Tour Tour { get; private set; }
    }
}
