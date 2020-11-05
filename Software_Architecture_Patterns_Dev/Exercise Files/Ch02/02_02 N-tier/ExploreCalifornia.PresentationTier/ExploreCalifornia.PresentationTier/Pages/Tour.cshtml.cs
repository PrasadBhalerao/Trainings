using ExploreCalifornia.PresentationTier.Business;
using ExploreCalifornia.PresentationTier.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.PresentationTier.Pages
{
    public class TourModel : PageModel
    {
        private readonly IToursProxy _toursProxy;

        public TourModel(IToursProxy toursProxy)
        {
            _toursProxy = toursProxy;
        }

        public void OnGet(int id)
        {
            Tour = _toursProxy.GetTour(id);
        }

        public Tour Tour { get; private set; }
    }
}
