using System.Collections.Generic;
using ExploreCalifornia.PresentationTier.Business;
using ExploreCalifornia.PresentationTier.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.PresentationTier.Pages
{
    public class ToursModel : PageModel
    {
        private readonly IToursProxy _proxy;

        public ToursModel(IToursProxy proxy)
        {
            _proxy = proxy;
        }

        public void OnGet()
        {
            Tours = _proxy.GetTours();
        }

        public IEnumerable<Tour> Tours { get; private set; }
    }
}
