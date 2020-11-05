using System.Collections.Generic;
using ExploreCalifornia.Monolith.DataAccess;
using ExploreCalifornia.Monolith.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Monolith.Pages
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
