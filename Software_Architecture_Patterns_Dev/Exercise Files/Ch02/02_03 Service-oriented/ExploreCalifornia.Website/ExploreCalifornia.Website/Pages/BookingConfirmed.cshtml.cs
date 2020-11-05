using ExploreCalifornia.Website.ESB;
using ExploreCalifornia.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Website.Pages
{
    public class BookingConfirmedModel : PageModel
    {
        private readonly IToursProxy _toursProxy;
        private readonly IBookingsProxy _bookingsProxy;
        public Tour Tour { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Transport { get; private set; }

        public BookingConfirmedModel(IToursProxy toursProxy, IBookingsProxy bookingsProxy)
        {
            _toursProxy = toursProxy;
            _bookingsProxy = bookingsProxy;
        }

        public void OnGet(int tourId, string name, string email, string transport)
        {
            Tour = _toursProxy.GetTour(tourId);
            Name = name;
            Email = email;
            Transport = transport == "on";
        }
    }
}
