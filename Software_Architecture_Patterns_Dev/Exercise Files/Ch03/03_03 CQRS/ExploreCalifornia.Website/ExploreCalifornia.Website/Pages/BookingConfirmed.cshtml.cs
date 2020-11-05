using ExploreCalifornia.Website.DataAccess;
using ExploreCalifornia.Website.DataAccess.WriteModel;
using ExploreCalifornia.Website.Domain;
using ExploreCalifornia.Website.Domain.WriteModel;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Website.Pages
{
    public class BookingConfirmedModel : PageModel
    {
        private readonly IToursRepository _toursRepository;
        public Tour Tour { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Transport { get; private set; }

        public BookingConfirmedModel(IToursRepository toursRepository)
        {
            _toursRepository = toursRepository;
        }

        public void OnGet(int tourId, string name, string email, string transport)
        {
            Tour = _toursRepository.GetTour(tourId);
            Name = name;
            Email = email;
            Transport = transport == "on";
        }
    }
}
