using ExploreCalifornia.Application.Tours;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Website.Pages
{
    public class TourModel : PageModel
    {
        private readonly ToursController _toursController;

        public TourModel(ToursController toursController)
        {
            _toursController = toursController;
        }

        public void OnGet(int id)
        {
            Tour = _toursController.GetTour(id);
        }

        public Tour Tour { get; private set; }
    }
}
