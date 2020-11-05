using System.Collections.Generic;
using ExploreCalifornia.Website.ExternalServices.Tours;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Website.Pages
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

        public IEnumerable<Models.Tour> Tours { get; private set; }
    }
}
