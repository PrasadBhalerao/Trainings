using ExploreCalifornia.CQRSES.DataAccess;
using ExploreCalifornia.CQRSES.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.CQRSES.Pages
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
