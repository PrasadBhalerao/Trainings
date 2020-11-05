using System.Collections.Generic;
using ExploreCalifornia.CQRSES.DataAccess;
using ExploreCalifornia.CQRSES.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.CQRSES.Pages
{
    public class ToursModel : PageModel
    {
        private readonly IToursRepository _repository;

        public ToursModel(IToursRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            Tours = _repository.GetTours();
        }

        public IEnumerable<Tour> Tours { get; private set; }
    }
}
