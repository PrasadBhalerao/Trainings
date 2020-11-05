using ExploreCalifornia.Monolith.DataAccess;
using ExploreCalifornia.Monolith.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Monolith.Pages
{
    public class TourModel : PageModel
    {
        private readonly IToursRepository _toursRepository;

        public TourModel(IToursRepository toursRepository)
        {
            _toursRepository = toursRepository;
        }

        public void OnGet(int id)
        {
            Tour = _toursRepository.GetTour(id);
        }

        public Tour Tour { get; private set; }
    }
}
