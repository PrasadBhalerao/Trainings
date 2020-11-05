using ExploreCalifornia.Application.Tours;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Website.Pages
{
    public class BookingConfirmedModel : PageModel
    {
        private readonly ToursController _toursController;
        public Tour Tour { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Transport { get; private set; }

        public BookingConfirmedModel(ToursController toursController)
        {
            _toursController = toursController;
        }

        public void OnGet(int tourId, string name, string email, string transport)
        {
            Tour = _toursController.GetTour(tourId);
            Name = name;
            Email = email;
            Transport = transport == "on";
        }
    }
}
