using System.Collections.Generic;
using ExploreCalifornia.Application.Tours;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Website.Pages
{
    public class ToursModel : PageModel
    {
        private readonly ToursController _toursController;

        public ToursModel(ToursController toursController)
        {
            _toursController = toursController;
        }

        public void OnGet()
        {
            Tours = _toursController.GetTours();
        }

        public IEnumerable<Tour> Tours { get; private set; }
    }
}
